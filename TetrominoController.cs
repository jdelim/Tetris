using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrominoController : MonoBehaviour
{
    #region T Tetromino
    public Rotation TSpin1 = new Rotation(0, -1, 1, 1, 1, 0, 2, -1);
    public Rotation TSpin2 = new Rotation(1, 0, 1, -1, 2, 1, -1, -2);
    public Rotation TSpin3 = new Rotation(0, -1, 1, 1, 2, -1, 1, 2);
    public Rotation TSpin4 = new Rotation(1, 0, 1, -1, -0, -1, 1, -2);
    public Tetromino TTetromino = new Tetromino(Vector2Int.zero, TSpin1, TSpin2, TSpin3, TSpin4);
    #endregion
    //TODO: Create a Vector2Int Covering the Origin Position
    //TODO: Create a set of four Vector2Ints that are for Rotation 1
    //TODO: Create a set of four Vector2Ints that are for Rotation 2
    //TODO: Create a set of four Vector2Ints that are for Rotation 3
    //TODO: Create a set of four Vector2Ints that are for Rotation 4
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
