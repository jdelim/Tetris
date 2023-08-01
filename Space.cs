using UnityEngine;

public class Space : MonoBehaviour
{
    public int col, row;
    public Sprite[] DisplayImage;
    public SpriteRenderer DisplayRenderer;
    public GameController Controller;
    public TetrominoController TetrisController;

    // Update is called once per frame
    public void Update()
    {
        int Current = 2;
        switch (Controller.CurrentGame)
        {
            case TargetScene.TicTacToe: 
                Current = (int)Controller.TicTacToeGame.Board[col, row]; break;
            case TargetScene.Connect4: 
                Current = (int)Controller.Connect4Game.Board[col, row]; break;
                //TODO: Create a case for Tetris check board for Tetromino
            case TargetScene.Tetris
                Current = (int)Controller.Tetris.Board[col, row].color; break;
                //TODO: Create code to reference the falling tetromino
                if(Current == 7 && TetrisController.isHere(col, row))
                {
                    Current = (int)TetrisController.CurrentTetromino;
                }
        }
        DisplayRenderer.sprite = DisplayImage[Current];
    }
    //TODO: Exclude Tetris from Execution
    public void OnMouseUpAsButton()
    {
        if (Controller.CurrentMode != TargetScene.Tetris)
        {
            Controller.GetInput(col, row);
        }
        
    }
}
