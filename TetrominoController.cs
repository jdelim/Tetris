using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrominoController : MonoBehaviour
{
    public int Score;
    public float dropSpeed, normalSpeed, hyperSpeed, maxnormalSpeed;
    public Tetromino Current;
    public Vector2 Position;
    //TODO: Adding Sound Effects
    //TODO: Adding the Music
    //TODO: Create an Enumerator for the Actions that Can Occur

    //TODO: Create the Tetromino List
    public List<TetrominoType> TetrominoList = new List<TetrominoType>();

    public GameController Controller;
    //TODO: Play Sound Corresponding With Sound Effect
    public void PlaySound()
    {

    }
    public void setDrop(bool HighSpeed)
    {
        dropSpeed = HighSpeed ? hyperSpeed : normalSpeed;
    }
    public Vector2Int Position;
    //TODO: *Create a method to check if a specific set of positions is available on the board
    public bool isRotationAvailable() //Hobbs
    {

    }
    //TODO: Can the tetromino go down
<<<<<<< HEAD
    public bool isNextPositionAvailable()
=======
    public bool isNextPositionAvailable(Vector2Int Position)
>>>>>>> master
    {
        bool output = true;
        Vector2Int[] CurrentPosition = Current.NextPosition(Position);  //Find where the tetromino would actually be if moved down
        foreach (Vector2Int given in CurrentPosition)                   //Loop through each position in the Positions Provided
        {
            if (Controller.TetrisGame.Board[given.x, given.y] != Position.Empty)
            {
                output = false;                                         //if any tetrmino block would be in a occupied position return false
            }
        }
        return output;                                                  //If none are occupied, return true
    }
    //TODO: Create a means to Access the Board
    public bool isPositionAvailable(int col, int row)
    {

    }
    //TODO: Move Left or Right - Indicate left or right
    public void MoveSideWays(int direction)
    {
        Position.x = Position.x + direction;
        
    }
    //TODO: Create a method to drop tetrominos every (preset) time
    public IEnumerator Drop(int Dropspeed) //Move Tetromino down every (dropspeed) seconds
    {
        if(Current == null) //If I don't have a Tetromino
        {
            CreateTetromino();                          //Make Sure New Tetromino Gets Created
        }
        yield return new WaitForSeconds(Dropspeed);
        if (isNextPositionAvailable()) GoDown(); 
        else Land();
    }
    //TODO: Go Down - Move Tetromino to lower position
    public void GoDown()
    {
        if(isNextPositionAvailable())
        {
            Position = new Vector2(Position.x, Position.y - 1);
        }
    }
    //TODO: Landing Program - Execute Tetris Input on Game Controller for each Position on Tetromino
    public void Land()
    {

    }
    //TODO: Create the List of Tetrominos so we know which one is next
    public void CreateTetrominoList()
    {
        for (int i = 0; i < 6; i++)//Repeat this process (x) number of times (four loop)
        {
            Random generator = new Random();                                         //Create Random Number Generator
            TetrominoType currentTetromino = (TetrominoType)generator.Next(0, 7);    //Create a random number between zero and six as Tetromino
            TetrominoList.Add(currentTetromino);                                     //Add it to the list
        }
    }
            
    }
    //TODO: Create a Tetromino and place at the top to start falling
    public void CreateTetromino()
    {
        Random RNG = new Random();                              //Create A Random Number Generator
        Position = new Vector2Int(5, 22);                       //Reset Position
        Current = new Tetromino(TetrominoList[0]);              //Create a New Tetromino
        TetrominoList().RemoveAt(0);                            //Remove the used tetromino type from the list
        //Add to the list so it never ends
        TetrominoType New = (TetrominoType) RNG.Next(0, 7);     //Make new tetromino type
        TetrominoList().Add(New);                               //Replace the tetromino removed so the list never ends
    }
    //TODO: Write the Start Method
    public void Start
    {
        //Create the Tetromino List
        //Start Drop Program
    }
    //TODO: Create a method to lower that amount of time
    public void ChangeTime()
    {
        //Adjust the Variables for Time
    }
    //TODO: Create a method to take input
    public void Update()
    {
        //Capture Input
        if(input.OnKeyDown(KeyCode.LeftArrow)){
            MoveSideWays('Left');
        }
        if(input.OnKeyDown(KeyCode.DownArrow)){
            GoDown();
        }
        if(input.OnKeyDown(KeyCode.RightArrow)){
            MoveSideWays('Right');
        }
        if(input.OnKeyDown(KeyCode.UpArrow)){
            Current.ChangeRotation()
        }
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
                Spin3 = new Rotation(0, 1, 0, -1, 1, -1, 0, 0);
                Spin4 = new Rotation(-1, -1, -1, 0, 1, 0, 0, 0);
                break;
            case TetrominoType.Z:
                Spin1 = new Rotation(-1, 1, 0, 1, 1, 0, 0, 0);
                Spin2 = new Rotation(0, -1, 1, 0, 1, 1, 0, 0);
                Spin3 = new Rotation(-1, 0, 0, -1, 1, -1, 0, 0);
                Spin4 = new Rotation(-1, -1, -1, 0, 0, 1, 0, 0);
                break;
            case TetrominoType.Square:
                Spin1 = new Rotation(new Rotation(0, 0, 0, 1, 1, 0, 1, 1));
                Spin2 = new Rotation(new Rotation(0, 0, 0, 1, 1, 0, 1, 1));
                Spin3 = new Rotation(new Rotation(0, 0, 0, 1, 1, 0, 1, 1));
                Spin4 = new Rotation(new Rotation(0, 0, 0, 1, 1, 0, 1, 1));
                break;
            case TetrominoType.S:
                Spin1 = new Rotation(1, 1, 0, 1, -1, 0, 0, 0);
                Spin2 = new Rotation(0, 1, 1, -1, 1, 0, 0, 0);
                Spin3 = new Rotation(-1, -1, 0, -1, 1, 0, 0, 0);
                Spin4 = new Rotation(-1, 1, -1, 0, 0, -1, 0, 0);
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
            output[0] = Position + Rotations[CurrentRotation].Placement[i];
        }
        return output;
    }
    //Gives Actual Board position of Tetromino blocks in specific rotation when given actual position
    public Vector2Int[] ActualPosition(Vector2Int Position, int rotation)
    {
        Vector2Int[] output = new Vector2Int[4];
        for (int i = 0; i < 4; i++)
        {
            output[0] = Position + Rotations[rotation].Placement[i];
        }
        return output;
    }
    //Gives Actual Board position of Tetromino blocks if moved down one
    public Vector2Int[] NextPosition(Vector2Int Position)
    {
        Vector2Int[] CurrentPosition = ActualPosition(Position);
        foreach (Vector2Int given in CurrentPosition) given.y--;
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
    public Rotation(params int placements)
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
//To Be Deleted
public enum TetrominoType
{
    Line, T, L, ReverseL, S, Z, Square, Empty
}
