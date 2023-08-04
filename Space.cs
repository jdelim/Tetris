using UnityEngine;
public class Space : MonoBehaviour
{
    public int col, row;
    public Sprite[] DisplayImage;
    public SpriteRenderer DisplayRenderer;
    public GameController Controller;
    // Update is called once per frame
    public void Update()
    {
       int Current = Controller.GetValue(col, row);
       DisplayRenderer.sprite = DisplayImage[Current];
    }
    //Exclude Tetris from Execution
    public void OnMouseUpAsButton()
    {
        if (Controller.CurrentGame != TargetScene.Tetris)
        {
            Controller.GetInput(col, row);
        }
        
    }
}
