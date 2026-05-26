using UnityEngine;

public class PuzzleClickableObject : InteractableObject
{
    [SerializeField] private string objectId;
    [SerializeField] private SequencePuzzleController puzzleController;

    public string ObjectId => objectId;

    public override void Interact()
    {
        puzzleController.RegisterObjectClick(this);
    }

    private void OnMouseDown()
    {
        Interact();
    }
}
