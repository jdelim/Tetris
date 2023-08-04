using UnityEngine;
[RequiredComponent(typeof(BoxCollider2D))]
public class TabletButton : MonoBehaviour
{
    public MoveDirection Current;
    public Tetromino Controller;
    public void OnMouseUpAsButton()
    {
        if (TetrominoController.Current != null) { return; }
        switch (Current)
        {
            case MoveDirection.Left: Controller.MoveSideWays(-1); break;
            case MoveDirection.Right: Controller.MoveSideWays(1); break;
            case MoveDirection.Up:

                int NewRotation = Controller.isRotationAvailable();
                if (TetrominoController.CurrentRotation != NewRotation)
                {
                    TetrominoController.ChangeRotation(NewRotation);
                    Controller.playSound(Act.Rotate);
                }
                break;
            case MoveDirection.Down:
                if (Controller.canDrop)
                {
                    Controller.GoDown();
                    StartCoroutine(Controller.SuperDrop());
                }
                break;
        }
    }
}

public enum MoveDirection
{
    Up, Down, Left, Right;
}