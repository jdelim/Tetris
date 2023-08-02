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
    public bool isNextPositionAvailable() 
    {

    }
    //TODO: Create a means to Access the Board
    public bool isPositionAvailable(int col, int row)
    {

    }
    //TODO: Move Left or Right - Indicate left or right
    public void MoveSideWays()
    {

    }
    //TODO: Create a method to drop tetrominos every (preset) time
    public IEnumerator Drop() //Move Tetromino down every (dropspeed) seconds
    {
        //Do I have a Tetromino
            //Create a Tetromino
        //Wait a Preset Amount of Time
        //Can the Tetromino Go Down
            //Go Down
        //Otherwise
            //Land
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

    }
    //TODO: Create a Tetromino and place at the top to start falling
    public void CreateTetromino()
    {
        //Add to the list so it never ends
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
