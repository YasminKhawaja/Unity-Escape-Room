using UnityEngine;

public class RiddleNoteInteractable : InteractableBase
{
    [SerializeField] private RoomPuzzleState roomPuzzleState;
    [SerializeField] private HudUIController hudUIController;
    [SerializeField] private string riddleText;

    public override void Interact()
    {
        roomPuzzleState.SetRiddleRead();
        hudUIController.ShowMessage(riddleText);
    }
}