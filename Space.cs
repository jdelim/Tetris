using UnityEngine;

public class Space : MonoBehaviour
{
    public int col, row;
    public Sprite[] DisplayImage;
    public SpriteRenderer DisplayRenderer;
    public GameController Controller;
    //TODO: Way to distinguish which tetromino block you should be showing

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
                //TODO: Create code to reference the falling tetromino
        }
        DisplayRenderer.sprite = DisplayImage[Current];
    }
    //TODO: Exclude Tetris from Execution
    public void OnMouseUpAsButton()
    {
            Controller.GetInput(col, row);
        
    }
}
