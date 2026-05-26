using UnityEngine;

public class BookshelfRiddleSwitch : InteractableBase
{
    [SerializeField] private RoomPuzzleState roomPuzzleState;
    [SerializeField] private TreasureChestController treasureChestController;
    [SerializeField] private AudioSource clickAudioSource;

    private bool isActivated;

    public override void Interact()
    {
        if (isActivated)
        {
            return;
        }

        isActivated = true;

        if (clickAudioSource != null)
        {
            clickAudioSource.Play();
        }

        roomPuzzleState.UnlockChest();
        treasureChestController.OpenChest();
    }
}