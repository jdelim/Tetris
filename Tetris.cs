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
    bool DetectfullLineForOneLine(int row)
    {
        for (int i = 0; i < 10; i++)
        {
            if (!Board[i, row].isActive)
            {
                return false
            }
        }
        return true;
    }
    void DetectFullLine() 
    {
        List<int> ToBeDestroyed = new List<int>();
        for(int i = 0; i<20; i++)
        {
            if(DetectfullLineForOneLine(i))
            {
                ToBeDestroyed.Add(i);
            }
        }
        DestroyedRows = ToBeDestroyed.ToArray();
    }

    // TODO: create method which checks the board 

    // TODO: create method which clears a line

    // TODO: create method which destroys full rows
    public void DestroyFullLine()
    {
        if(FullLine == true)
        {
            set(placeBlock = space.empty);
        }
    }

    // TODO: create a method which moves board down after blocks destroyed

    // TODO: create a method which updates the board
}