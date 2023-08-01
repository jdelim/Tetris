using System.Collections.Generic;
public enum TetrominoType
{
    Line, T, L, ReverseL, S, Z, Square
}
public class Block
{
    #region Fields
    private bool active;
    public TetrominoType color;
    #endregion
    #region Properties
    public bool isActive { get { return active; } }
    public bool makeActive { set { active = value; } }
    #endregion
    #region Constructors
    public Block()
    {
        active = false;
    }
    public Block(TetrominoType current)
    {
        active = true;
        color = current;
    }
    #endregion
}
public class Tetris
{
    #region Fields
    public Block[,] Board;
    private int[] DestroyedRows;
    #endregion
    #region Constructor
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
    #endregion
    #region Methods
    #region Make Move
    //Method to place blocks
    public void Move(int x, int y, TetrominoType aColor)
    {
        Board[x, y] = new Block(aColor);
    }
    //Method Updates the Entire Game After Move Complete
    public void MoveComplete()
    {
        CheckBoard();
        AllClear();
        UpdateBoard();
        DestroyedRows = new int[0];
    }
    #endregion
    #region Line Detection
    //Method to detect one line of blocks
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
    //Method to Check Board for full lines
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
    #endregion
    #region Line Clear
    //Method Clears one line
    public void RowClear(int row)
    {
        for (int i = 0; i < 10; i++)
        {
            Board[i, row] = new Block();
        }
    }
    //Clears all rows on destroy list
    void AllClear() 
    { 
        for (int i = 0; i<DestroyedRows.Length; i++ ) 
        {
            RowClear(DestroyedRows[i]);
        }
    }
    #endregion
    #region Update After Clear
    //Moves one row down Correct Number of Blocks After Blocks Are Destroyed
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
    //Method which updates the board
    void UpdateBoard() 
    {
        for (int row = 0; row < 20; row++)
        {
            MoveDown(row);
        }
    }
    #endregion
    #endregion
}
