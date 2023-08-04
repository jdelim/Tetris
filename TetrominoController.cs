using BoardGames;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class TetrominoController : MonoBehaviour
{
    public int Score, Level;
    public bool canDrop;
    public float dropSpeed, normalSpeed, hyperSpeed, maxnormalSpeed;
    public float[] normalSpeeds;
    public static Tetromino Current;
    public AudioSource MusicPlayer;
    public AudioClip MusicFile;
    public AudioSource SoundEffectPlayer;
    public AudioClip[] SoundEffect;
    public List<TetrominoType> TetrominoList = new List<TetrominoType>();
    public GameController Controller;
    public Vector2Int Position;
    public TextMeshPro DisplayScore;
    public bool isHere(int col, int row)
    {
        if (Current == null) return false;
        Vector2Int[] Positions = Current.ActualPosition(Position);
        Vector2Int Test = new Vector2Int(col, row);
        foreach(Vector2Int given in Positions) if(Test == given) return true;
        return false;
    }
    //Play Sound Based on Act Performed
    public void playSound(Act Current)
    {
        //1.Assign current AudioClip to audiosource
        SoundEffectPlayer.clip = SoundEffect[(int) Current];
        //2.Play Audio
        SoundEffectPlayer.Play();
    }
    //Play Game Music
    public void playMusic()
    {
        MusicPlayer.loop = true;
        MusicPlayer.clip = MusicFile; //1.Assign current AudioClip to audiosource
        MusicPlayer.Play();//2.Play Audio
    }    
    //Set Drop Speed
    public void setDropSpeed(bool HighSpeed)
    {
        dropSpeed = HighSpeed ? hyperSpeed : normalSpeed;
    }
    //Check if a specific set of positions is available on the board
    public bool CheckPosition(Vector2Int[] CurrentPosition)
    {
        //Loop through each position in the Positions Provided
        foreach (Vector2Int given in CurrentPosition)                   
        {
            if (Controller.GetValue(given.x, given.y, true) != 7) return false;
        }
        return true;
    }
    //Send out the Available Rotation
    public int isRotationAvailable()
    {
        if(Current == null) return 0;
        //Store the Current Rotation as output
        int output = Current.CurrentRotation;
        //Store the current equal to output + 1
        int current = output + 1;
        //If current is greater than three then set to zero
        if (current > 3) current = 0;
        //While current does not equal output
        while (current != output)
        {
            Vector2Int[] Actual = Current.ActualPosition(Position, current);//Get the Actual Position of the Tetromino given a current rotation
            if (CheckPosition(Actual)) output = current;                    //If each position set output = to current
            else//Otherwise
            {
                current++;//Increase Current
                if (current > 3) current = 0;//If current is greater than three then set to zero
            }
        }
        return output;//return output
    }
    //Check if the next position is available
    public bool isNextPositionAvailable()
    {
        bool output = true;
        Vector2Int[] CurrentPosition = Current.NextPosition(Position);  //Find where the tetromino would actually be if moved down
        output = CheckPosition(CurrentPosition);
        return output;                                                  //If none are occupied, return true
    }
    //Move Left or Right - Indicate left or right
    public void MoveSideWays(int direction)
    {
        if(Current == null) return;
        //Determine the New Position
        Vector2Int NewPosition = Position + Vector2Int.right * direction;
        //Get What Positions Would be taken there
        Vector2Int[] ActualPositions = Current.ActualPosition(NewPosition);
        //If the Position is Available change position to new position
        if (CheckPosition(ActualPositions))
        {
            Position = NewPosition;
            playSound(Act.Shift);
        }
    }
    //Drop tetrominos every (preset) time
    public IEnumerator Drop() //Move Tetromino down every (dropspeed) seconds
    {
        if(Current == null) //If I don't have a Tetromino
        {
            CreateTetromino(); //Make Tetromino
        }
        yield return new WaitForSeconds(dropSpeed); //Wait for Current Time Frame
        GoDown();                                   //Go Down
        yield return new WaitUntil(()=>Controller.isReady);
        if (!Controller.TetrisGameOver) StartCoroutine(Drop()); //Repeat if Game is not over
    }
    //Go Down
    public void GoDown()
    {
        if (Current == null) return;
        //Determine the New Position
        Vector2Int NewPosition = Position + Vector2Int.down;
        //Get What Positions Would be taken there
        Vector2Int[] ActualPositions = Current.ActualPosition(NewPosition);
        if (dropSpeed == hyperSpeed) Score += 15; else Score += 5;
        //If the Position is Available change position to new position
        if (CheckPosition(ActualPositions)) Position = NewPosition;
        else Land();
    }
    //Execute Tetris Input on Game Controller for each Position on Tetromino
    public void Land()
    {
        Vector2Int[] ActualPosition = Current.ActualPosition(Position);
        foreach (Vector2Int given in ActualPosition)
        {
            if (given.y >= 20)
            {
                Controller.TetrisGameOver = true;
            }
            else Controller.GetInput(given.x, given.y);
        }
        if (Controller.TetrisGameOver)
        {
            MusicPlayer.Stop();
            playSound(Act.GameOver);
            return;
        }
        playSound(Act.Land);
        StartCoroutine(Controller.UpdateTetris());
        int RowsDestroyed = Controller.TetrisGame.RowsDestroyed;
        if (RowsDestroyed == 4)
        {
            playSound(Act.DestroyTetris);
            Score += 1000;
        }
        else if (RowsDestroyed > 0)
        {
            playSound(Act.DestroyLine);
            Score += 200 * RowsDestroyed;
        }
        int CurrentLevel = Level;
        Level = Mathf.Clamp(Score / 5000, 0, 9);
        if (Level > CurrentLevel) playSound(Act.LevelUp);
        normalSpeed = normalSpeeds[Level];
        Current = null;
    }
    //Create the List of Tetrominos so we know which one is next
    public void CreateTetrominoList()
    {
        for (int i = 0; i < 7; i++)//Repeat this process (x) number of times (four loop)
        {
            TetrominoType currentTetromino = (TetrominoType) Random.Range(0, 7);    //Create a random number between zero and six as Tetromino
            TetrominoList.Add(currentTetromino);                                     //Add it to the list
        }
    }
    //Create a Tetromino and place at the top to start falling
    public void CreateTetromino()
    {
        Position = new Vector2Int(5, 22);                           //Reset Position
        Current = new Tetromino(TetrominoList[0]);                  //Create a New Tetromino
        TetrominoList.RemoveAt(0);                                  //Remove the used tetromino type from the list
        TetrominoType New = (TetrominoType) Random.Range(0, 7);     //Make new tetromino type
        TetrominoList.Add(New);                                     //Add to the list so it never ends
    }
    //Write the Start Method
    void Start()
    {
        Controller = GetComponent<GameController>();
        CreateTetrominoList();//Create the Tetromino List
        StartCoroutine(Drop());//Start Drop Program
        playMusic();
        canDrop = true;
    }
    
    //Create a method to lower that amount of time
    public IEnumerator SuperDrop()
    {
        if (canDrop)
        {
            canDrop = false;
            yield return new WaitForSeconds(hyperSpeed);
            canDrop = true;
        }
    }
    //Create a method to take input
    public void Update()
    {
        if (Current == null) return;
        //Capture Input
        if(Input.GetKeyDown(KeyCode.LeftArrow)){
            MoveSideWays(-1);
        }
        if(Input.GetKey(KeyCode.DownArrow))
        {
            if(canDrop)
            {
                GoDown();
                StartCoroutine(SuperDrop());
            }
        }
        else
        {
            setDropSpeed(false);
        }
        if(Input.GetKeyDown(KeyCode.RightArrow)){
            MoveSideWays(1);
        }
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            int NewRotation = isRotationAvailable();
            if(Current.CurrentRotation != NewRotation)
            {
                Current.ChangeRotation(NewRotation);
                playSound(Act.Rotate);
            }
        }
        DisplayScore.text = "Score\n" + Score.ToString();
    }
}
public class Tetromino
{
    #region Fields
    public Rotation[] Rotations;
    public int CurrentRotation;
    public TetrominoType CurrentType;
    #endregion
    #region Constructor
    public Tetromino(TetrominoType TypeRequested)
    {
        CurrentRotation = 0;
        CurrentType = TypeRequested;
        Rotation Spin1, Spin2, Spin3, Spin4;
        switch(TypeRequested) 
        {
            case TetrominoType.L:
                Spin1 = new Rotation(1, 1, -1, 0, 1, 0, 0, 0);
                Spin2 = new Rotation(0, 1, 0, -1, 1, -1, 0, 0);
                Spin3 = new Rotation(-1, -1, -1, 0, 1, 0, 0, 0);
                Spin4 = new Rotation(0, 1, 0, -1, -1, 1, 0, 0);
                break;
            case TetrominoType.ReverseL:
                Spin1 = new Rotation(-1, 1, -1, 0, 1, 0, 0, 0);
                Spin2 = new Rotation(0, 1, 0, -1, 1, 1, 0, 0);
                Spin3 = new Rotation(-1, 0, 1, 0, 1, -1, 0, 0);
                Spin4 = new Rotation(-1, -1, 0, -1, 0, 1, 0, 0);
                break;
            case TetrominoType.Z:
                Spin1 = new Rotation(-1, 1, 0, 1, 1, 0, 0, 0);
                Spin2 = new Rotation(0, -1, 1, 0, 1, 1, 0, 0);
                Spin3 = new Rotation(-1, 0, 0, -1, 1, -1, 0, 0);
                Spin4 = new Rotation(-1, -1, -1, 0, 0, 1, 0, 0);
                break;
            case TetrominoType.Square:
                Spin1 = new Rotation(0, 0, 0, 1, 1, 0, 1, 1);
                Spin2 = new Rotation(0, 0, 0, 1, 1, 0, 1, 1);
                Spin3 = new Rotation(0, 0, 0, 1, 1, 0, 1, 1);
                Spin4 = new Rotation(0, 0, 0, 1, 1, 0, 1, 1);
                break;
            case TetrominoType.S:
                Spin1 = new Rotation(1, 1, 0, 1, -1, 0, 0, 0);
                Spin2 = new Rotation(0, 1, 1, -1, 1, 0, 0, 0);
                Spin3 = new Rotation(-1, -1, 0, -1, 1, 0, 0, 0);
                Spin4 = new Rotation(-1, 1, -1, 0, 0, -1, 0, 0);
                break;
            case TetrominoType.T:
                Spin1 = new Rotation(-1, 0, 1, 0, 0, 1, 0, 0);
                Spin2 = new Rotation(0, 1, 0, -1, 1, 0, 0, 0);
                Spin3 = new Rotation(-1, 0, 1, 0, 0, -1, 0, 0);
                Spin4 = new Rotation(0, 1, 0, -1, -1, 0, 0, 0);
                break;
            default: //Line
                Spin1 = new Rotation(0, 1, 1, 1, 2, 1, 3, 1);
                Spin2 = new Rotation(2, 0, 2, 1, 2, 2, 2, 3);
                Spin3 = new Rotation(0, 2, 1, 2, 2, 2, 3, 2);
                Spin4 = new Rotation(1, 0, 1, 1, 1, 2, 1, 3);
                break;
        }
        Rotations = new Rotation[] { Spin1, Spin2, Spin3, Spin4 };
    }
    #endregion
    #region Methods
    //Gives Actual Board position of Tetromino blocks when given actual position
    public Vector2Int[] ActualPosition(Vector2Int Position)
    {
        Vector2Int[] output = new Vector2Int[4];
        for (int i = 0; i < 4; i++)
        {
            output[i] = Position + Rotations[CurrentRotation].Placement[i];
        }
        return output;
    }
    //Gives Actual Board position of Tetromino blocks in specific rotation when given actual position
    public Vector2Int[] ActualPosition(Vector2Int Position, int rotation)
    {
        Vector2Int[] output = new Vector2Int[4];
        for (int i = 0; i < 4; i++)
        {
            output[i] = Position + Rotations[rotation].Placement[i];
        }
        return output;
    }
    //Gives Actual Board position of Tetromino blocks if moved down one
    public Vector2Int[] NextPosition(Vector2Int Position)
    {
        Vector2Int[] CurrentPosition = ActualPosition(Position);
        for (int i = 0; i < CurrentPosition.Length; i++) CurrentPosition[i].y--;
        return CurrentPosition;
    }
    //Change Rotation to Rotation Selected
    public void ChangeRotation(int newRotation)
    {
        CurrentRotation = newRotation;
    }
    #endregion
}
public class Rotation
{
    public Vector2Int[] Placement;
    public Rotation(params int[] placements)
    {
        Placement = new Vector2Int[4];
        int counter = 0;
        for(int i = 0; i < 8; i += 2)
        {
            Vector2Int position = new Vector2Int(placements[i], placements[i + 1]);
            Placement[counter] = position;
            counter++;
        }
    }
}
//TODO: Create an Enumerator for the Actions that Can Occur
public enum Act
{
    Shift, Rotate, Land, DestroyLine, DestroyTetris, LevelUp, GameOver
}
