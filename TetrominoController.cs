using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrominoController : MonoBehaviour
{
    public static TetrominoType CurrentType;
    public Tetromino Current;
    #region L Tetromino
    public Rotation LSpin1 = new Rotation(1, 1, -1, 0, 1, 0, 0, 0);
    public Rotation LSpin2 = new Rotation(0, 1, 0, -1, 1, -1, 0, 0);
    public Rotation LSpin3 = new Rotation(-1, -1, -1, 0, 1, 0, 0, 0);
    public Rotation LSpin4 = new Rotation(0, 1, 0, -1, -1, 1, 0, 0);
    public Tetromino LTetromino = new Tetromino(Vector2Int.zero, LSpin1, LSpin2, LSpin3, LSpin4);
    #endregion
    #region Reverse L Tetromino
    public Rotation RevLSpin1 = new Rotation(-1, 1, -1, 0, 1, 0, 0, 0);
    public Rotation RevLSpin2 = new Rotation(0, 1, 0, -1, 1, 1, 0, 0);
    public Rotation RevLSpin3 = new Rotation(0, 1, 0, -1, 1, -1, 0, 0);
    public Rotation RevLSpin4 = new Rotation(-1, -1, -1, 0, 1, 0, 0, 0);
    public Tetromino RevLTetromino = new Tetromino(Vector2Int.zero, RevLSpin1, RevLSpin2, RevLSpin3, RevLSpin4);
    #endregion
    //TODO: Create a Vector2Int Covering the Origin Position
    //TODO: Create a set of four Vector2Ints that are for Rotation 1
    //TODO: Create a set of four Vector2Ints that are for Rotation 2
    //TODO: Create a set of four Vector2Ints that are for Rotation 3
    //TODO: Create a set of four Vector2Ints that are for Rotation 4
    #region Z Tetromino
    public Rotation ZSpin1 = new Rotation(-1, 1, 0, 1, 1, 0, 0, 0);
    public Rotation ZSpin2 = new Rotation(0, -1, 1, 0, 1, 1, 0, 0);
    public Rotation ZSpin3 = new Rotation(-1, 0, 0, -1, 1, -1, 0, 0);
    public Rotation ZSpin4 = new Rotation(-1, -1, -1, 0, 0, 1, 0, 0);
    public Tetromino ZTetromino = new Tetromino(Vector2Int.zero, ZSpin1, ZSpin2, ZSpin3, ZSpin4);
    #endregion
    #region Line Tetromino
    public Rotation LineSpin1 = new Rotation(0, 1, 1, 1, 2, 1, 3, 1);
    public Rotation LineSpin2 = new Rotation(2, 0, 2, 1, 2, 2, 2, 3);
    public Rotation LineSpin3 = new Rotation(0, 2, 1, 2, 2, 2, 3, 2);
    public Rotation LineSpin4 = new Rotation(1, 0, 1, 1, 1, 2, 1, 3);
    public Tetromino LineTetromino = new Tetromino(Vector2Int.zero, LineSpin1, LineSpin2, LineSpin3, LineSpin4);
    #endregion
    //TODO: *Create a method to check if a specific set of positions is available on the board
    //TODO: Create a means to Access the Board
    //TODO: Create a method to drop tetrominos every (preset) time
    //TODO: Create a method to lower that amount of time
    //TODO: Create a method to take input

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
public class Tetromino
{
    public Vector2Int Origin;
    public Rotation[] Rotations;
    public int CurrentRotation;
    public Tetromino(Vector2Int orig, params Rotation[] rotations)
    {
        Origin = orig;
        Rotations = rotations;
        CurrentRotation = 0;
    }
    public Vector2Int[] ActualPosition(Vector2Int Position)
    {
        Vector2Int[] output = new Vector2Int[4];
        for (int i = 0; i < 4; i++)
        {
            output[0] = Position + Rotations[CurrentRotation].Placement[i];
        }
        return output;
    }
    public Vector2Int[] ActualPosition(Vector2Int Position, int rotation)
    {
        Vector2Int[] output = new Vector2Int[4];
        for (int i = 0; i < 4; i++)
        {
            output[0] = Position + Rotations[rotation].Placement[i];
        }
        return output;
    }
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
