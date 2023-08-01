using BoardGames;
using UnityEngine;
using TMPro;
using System.Collections;

public class GameController : MonoBehaviour
{
    public GameObject Connect4Position;
    public TargetScene CurrentGame;
    //TODO: Add Tetris Game
    public TicTacToe TicTacToeGame;
    public Connect4 Connect4Game;
    public TextMeshPro P1WinCount;
    public TextMeshPro P2WinCount;
    private int P1Wins, P2Wins;
    public void GetInput(int col, int row)
    {
        switch (CurrentGame)
        {
            case TargetScene.TicTacToe: TicTacToeInput(col, row); break;
            case TargetScene.Connect4: Connect4Input(col); break;
            //TODO: Create a case for after the Tetromino Lands
        }
    }
    public void Connect4Input(int col)
    {
        if (Connect4Game.CurrentState != GameState.Playing)
        {
            Connect4Game = new Connect4();
            return;
        }
        Connect4Game.Move(col);
        if (Connect4Game.CurrentState == GameState.Player1Win) P1Wins++;
        if (Connect4Game.CurrentState == GameState.Player2Win) P2Wins++;
        P1WinCount.text = "Player 1 Win Count\n" + P1Wins.ToString();
        P2WinCount.text = "Player 2 Win Count\n" + P2Wins.ToString();
    }
    public void TicTacToeInput(int col, int row)
    {
        if (TicTacToeGame.CurrentState != GameState.Playing)
        {
            TicTacToeGame = new TicTacToe();
            return;
        }
        TicTacToeGame.Move(col, row);
        if (TicTacToeGame.CurrentState == GameState.Player1Win) P1Wins++;
        if (TicTacToeGame.CurrentState == GameState.Player2Win) P2Wins++;
        P1WinCount.text = "Player 1 Win Count\n" + P1Wins.ToString();
        P2WinCount.text = "Player 2 Win Count\n" + P2Wins.ToString();
    }
    //TODO: Create a Tetris version of input
    //TODO: Find way to communicate what tetromino type
    
    // Start is called before the first frame update
    void Start()
    {
        switch (CurrentGame)
        {
            case TargetScene.TicTacToe:  TicTacToeGame = new TicTacToe();  break;
            case TargetScene.Connect4: 
                Connect4Game = new Connect4();
                CreateSpaces();
                break;
            //TODO: Create Target for Tetris
        }
        P1Wins = 0;
        P2Wins = 0;
    }
    //TODO: Modify Create Space to handle Tetris
    public void CreateSpaces()
    {
        for (int col = 0; col < 7; col++)
        {
            for (int row = 0; row < 6; row++)
            {
                GameObject Current = Instantiate(Connect4Position);  //Creates the Position
                Space CurrentSpace = Current.GetComponent<Space>();  //Created a reference to the space
                CurrentSpace.col = col;                              //Set the col
                CurrentSpace.row = row;                              //Set the row
                CurrentSpace.Controller = this;                      //Set the controller
                Current.transform.SetParent(transform);              //Set Current Object's parent
                Current.transform.localScale = Vector3.one;          //Scale to proper size
                //Find Local Position
                Vector3 pos = new Vector3(-1.44f + .48f * col, -1.2f + .48f * (5 - row), 1);
                Current.transform.localPosition = pos;               //Set Local Position
                /*
                    public int col, row;
                    public Sprite[] DisplayImage;
                    public SpriteRenderer DisplayRenderer;
                    public GameController Controller; 
                 */
            }
        }
    }
}