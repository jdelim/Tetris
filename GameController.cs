using BoardGames;
using UnityEngine;
using TMPro;
using System.Collections;
public class GameController : MonoBehaviour
{
    public GameObject Connect4Position;
    public TargetScene CurrentGame;
    public Tetris TetrisGame;
    public TicTacToe TicTacToeGame;
    public Connect4 Connect4Game;
    public TextMeshPro P1WinCount;
    public TextMeshPro P2WinCount;
    public TetrominoController Controller;
    public float start_x, start_y, delta_position;
    private int P1Wins, P2Wins;
    public bool TetrisGameOver, isReady;
    public int Score, Level;
    //Get Position Value and returns it as an integer
    public int GetValue(int col, int row, bool ignoretop = false)
    {
        int output = -1;
        switch(CurrentGame) 
        {
            case TargetScene.Tetris:
                Coordinate Check = new Coordinate(col, row); 
                if (!Check.inBounds())
                {
                    if (col < 0 || col > 9) return -1;
                    if (ignoretop && row > 19) return 7;
                    return -1;
                }
                output = (int)TetrisGame.Board[col, row].color;
                if (!ignoretop)
                { 
                    if(output == 7 && Controller.isHere(col, row)) output = (int)TetrominoController.Current.CurrentType;
                }
                break;
            case TargetScene.TicTacToe: output = (int)TicTacToeGame.Board[col, row]; break;
            case TargetScene.Connect4: output = (int)Connect4Game.Board[col, row]; break;
        }
        return output;
    }
    public void GetInput(int col, int row)
    {
        switch (CurrentGame)
        {
            case TargetScene.TicTacToe: TicTacToeInput(col, row); break;
            case TargetScene.Connect4: Connect4Input(col); break;
            case TargetScene.Tetris: TetrisInput(col, row); break;
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
    //Create a Tetris version of input
    public void TetrisInput(int col, int row)
    {
        TetrisGame.Move(col, row, TetrominoController.Current.CurrentType);
    }
    //Update the Tetris Game
    public IEnumerator UpdateTetris()
    {
        isReady = false;
        TetrisGame.CheckBoard();
        int DestroyedRows = TetrisGame.DestroyedRows.Length;
        if(DestroyedRows > 0)
        {
            for(int i = 0; i < 14; i++)
            {
                foreach(int given in TetrisGame.DestroyedRows)
                {
                    ChangeColor(i % 7);
                }
                yield return new WaitForSeconds(0.05f);
            }
            TetrisGame.AllClear();
            TetrisGame.UpdateBoard();
            TetrisGame.DestroyedRows = new int[0];
        }
        isReady = true;
    }
    public void ChangeColor(int value)
    {
        foreach (int given in TetrisGame.DestroyedRows)
        {
            for (int i = 0; i < 10; i++)
            {
                TetrisGame.Board[i, given].color = (TetrominoType)value;
            }
        }
    }
    // Start is called before the first frame update
    void Awake()
    {
        switch (CurrentGame)
        {
            case TargetScene.TicTacToe:  TicTacToeGame = new TicTacToe();  break;
            case TargetScene.Connect4: 
                Connect4Game = new Connect4();
                CreateSpaces();
                break;
            case TargetScene.Tetris:
                TetrisGame = new Tetris();
                CreateTetris();
                TetrisGameOver = false;
                Score = 0;
                Level = 1;
                TetrisGameOver = false;
                isReady = true;
                break;
        }
        P1Wins = 0;
        P2Wins = 0;
    }
    //Modify Create Space to handle Tetris
    public void CreateSpaces(int x = 7, int y = 6)
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
                Vector3 pos = new Vector3(start_x + delta_position * col, start_y + delta_position * ((y - 1) - row), 1);
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
    public void CreateTetris()
    {
        for (int col = 0; col < 10; col++)
        {
            for (int row = 0; row < 20; row++)
            {
                GameObject Current = Instantiate(Connect4Position);  //Creates the Position
                Space CurrentSpace = Current.GetComponent<Space>();  //Created a reference to the space
                CurrentSpace.col = col;                              //Set the col
                CurrentSpace.row = row;                              //Set the row
                CurrentSpace.Controller = this;                      //Set the controller
                Current.transform.SetParent(transform);              //Set Current Object's parent
                Current.transform.localScale = Vector3.one;          //Scale to proper size
                //Find Local Position
                Vector3 pos = new Vector3(start_x + delta_position * col, start_y + delta_position * row, 1);
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