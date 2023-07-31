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
        
    }
    // TODO: create method to place blocks
    public void Move(int x, int y, TetrominoType aColor)
    {
        Board[x, y] = new Block(aColor);
    }
}