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
        for(int row = 0; row<20; row++)
        {
            for(int col = 0; col<10; col++)
            {
                Board[col, row].isActive = false;
            }
        }
        DestroyedRows = new int[0];
    }
    // TODO: create method to place blocks
    public void Move(int x, int y, TetrominoType aColor)
    {
        Board[x, y] = new Block(aColor);
    }

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

    public void ClearLine(int row)
    {
        for(int i = 0; i < 10; i++)
        {
            Board[i, row] = false;
        }
    }

    // TODO: create method which destroys full rows
    public void RowCLear(int row)
    {
        if(DetectfullLineForOneLine == true)
        {
            for (int i = 10; i < 10; i++)
            {
                Board[i, row] = new Block();
            }
        }
    }



    // TODO: create a method which moves board down after blocks destroyed

    // TODO: create a method which updates the board
    void UpdateBoard() 
    {
        for (int row = 0; row < 20; row++)
        {
            MoveDown(row);
        }
    }
}