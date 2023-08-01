using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrominoController : MonoBehaviour
{
    #region L Tetromino
    public Rotation LSpin1 = new Rotation(1, 1, -1, 0, 1, 0, 0, 0);
    public Rotation LSpin2 = new Rotation(0, 1, 0, -1, 1, -1, 0, 0);
    public Rotation LSpin3 = new Rotation(0, 1, 0, -1, -1, 1, 0, 0);
    public Rotation LSpin4 = new Rotation(-1, -1, -1, 0, 1, 0, 0, 0);
    public Tetromino LTetromino = new Tetromino(new Vector2Int(5, 15), LSpin1, LSpin2, LSpin3, LSpin4);
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
    public Tetromino(Vector2Int orig, params Rotation[] rotations)
    {
        Origin = orig;
        Rotations = rotations;
    }
}
public class Rotation
{
    public Vector2Int[] Placement;
    public Rotation(params int placements)
    {
        Placement = new Vector2Int[4];
        for(int i = 0; i < 8; i += 2)
        {
            Vector2Int position1 = new Vector2Int(placements[i], placements[i + 1]);
        }
    }
}
