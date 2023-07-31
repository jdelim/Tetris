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
    public Block()
    {
        active = false;
    }
    public Block(TetrominoType current)
    {
        active = true;
        color = current;
    }
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
    void CheckBoard() 
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
    void AllClear() 
    { 
        for (int i = 0; i<DestroyedRows.Length; i++ ) 
        {
            ClearRow(DestroyedRows[i]);
        }
    }
    // TODO: create method which checks the board 

    // TODO: create method which clears a line

    // TODO: create method which destroys full rows
    public int RowCLear(int row)
    {
        if(DetectfullLineForOneLine == true)
        {
            for (int i = 10; i < 10; i++)
            {
                Board[i, row] = new Block();
                return i
            }
        }
    }

    // TODO: create a method which moves board down after blocks destroyed
    public void MoveDown(int row)
    {
        int fallcount = 0;
        foreach(int given in DestroyedRows) if(row > given) fallcount++;
        for(int i = 0; i < 10; i++)
        {
            Block[i, row - fallcount] = Block[i, row];
            Block[i, row] = new Block();
        }
    }
    // TODO: create a method which updates the board
}