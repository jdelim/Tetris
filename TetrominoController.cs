using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TetrominoMaker;

public class TetrominoController : MonoBehaviour
{
    public Rotation SquareSpin1 = new Rotation(new Rotation(0, 0, 0, 1, 1, 0, 1, 1));
    public Rotation SquareSpin2 = new Rotation(new Rotation(0, 0, 0, 1, 1, 0, 1, 1));
    public Rotation SquareSpin3 = new Rotation(new Rotation(0, 0, 0, 1, 1, 0, 1, 1));
    public Rotation SquareSpin4 = new Rotation(new Rotation(0, 0, 0, 1, 1, 0, 1, 1));
    public SquareTetro = new Tetromino(Vector2Int.zero, SquareSpin1, SquareSpin2, SquareSpin3, SquareSpin4);


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
99
    // Start is called before the first frame update
    void Start()
    {
     
        
    }
 
    // Update is called once per frame
    void Update()
    {
        
    }
}
