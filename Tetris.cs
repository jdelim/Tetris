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
    //TODO: Check Board for full line
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
    //TODO: Destroy all rows that are full
    void AllClear() 
    { 
        for (int i = 0; i<DestroyedRows.Length; i++ ) 
        {
            RowClear(DestroyedRows[i]);
        }
    }

    // TODO: create method which clears a line
    public void RowClear(int row)
    {
        for (int i = 0; i < 10; i++)
        {
            Board[i, row] = new Block();
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
    void UpdateBoard() 
    {
        for (int row = 0; row < 20; row++)
        {
            MoveDown(row);
        }
    }
}