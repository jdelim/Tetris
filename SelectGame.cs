using UnityEngine;
using UnityEngine.SceneManagement;
public class SelectGame : MonoBehaviour
{
    public Sprite ButtonSprite;
    public SpriteRenderer ButtonRenderer;
    public TargetScene Target;
    public void Start()
    {
        ButtonRenderer.sprite = ButtonSprite;
    }
    public void OnMouseUpAsButton()
    {
        SceneManager.LoadScene((int) Target);
    }
}

public enum TargetScene
{
    Lobby, TicTacToe, MineSweeper, Connect4, Tetris
}