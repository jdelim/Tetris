using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;

public class Prediction : MonoBehaviour
{
    public TetrominoController Controller;
    public GameObject[] Tile;
    public Sprite[] Sprites;
    public int Number;
    private Tetromino Current;
    private void Start()
    {
        Current = new Tetromino(BoardGames.TetrominoType.Empty);
    }
    // Update is called once per frame
    void Update()
    {
        if (Controller.TetrominoList[Number] != Current.CurrentType) { SetTetromino(); }
    }
    public void SetTetromino()
    {
        Current = new Tetromino(Controller.TetrominoList[Number]);
        for(int i = 0; i < 4; i++)
        {
            Vector2 Position = Current.Rotations[0].Placement[i];
            if (Current.CurrentType == BoardGames.TetrominoType.Line) 
            {
                Tile[i].transform.localPosition = Vector2.left * .36f + Position * 0.24f;
            }
            else if (Current.CurrentType == BoardGames.TetrominoType.Square)
            {
                Tile[i].transform.localPosition = Vector2.left * .12f + Position * 0.24f;
            }
            else Tile[i].transform.localPosition = Position * 0.24f;
            Tile[i].GetComponent<SpriteRenderer>().sprite = Sprites[(int)Current.CurrentType];
        }
    }

}
