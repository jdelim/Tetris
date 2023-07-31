using System.Collections.Generic;
public enum TetrominoType
{
    Line, T, L, ReverseL, S, Z, Square
}
public class Block
{
    private bool active;
    public TetrominoType color;
    public bool isActive { get { return active; } }
    public bool makeActive { set { active = value; } }
}
public class Tetris
{
    public Block[,] Board;
    private int[] DestroyedRows;
    public Tetris()
    {
        // TODO: finish constructor
    }
    // TODO: create method to place blocks

    // TODO: create method to detect a line of blocks

    // TODO: create method which checks the board 

    // TODO: create method which clears a line

    // TODO: create method which destroys full rows

    // TODO: create a method which moves board down after blocks destroyed

    // TODO: create a method which updates the board
}