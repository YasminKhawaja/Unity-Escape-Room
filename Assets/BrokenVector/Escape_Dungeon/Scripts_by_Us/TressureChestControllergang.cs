using UnityEngine;

public class TreasureChestControllergang : InteractableBase
{
    [SerializeField] private RoomPuzzleState roomPuzzleState;
    [SerializeField] private KeyPickUpInteractable keyPickupInteractable;
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource openAudioSource;
    [SerializeField] private Light chestFeedbackLight;

    private bool isUnlocked;
    private bool isOpened;

    public override void Interact()
    {
        if (!isUnlocked || isOpened)
        {
            return;
        }

        isOpened = true;
        roomPuzzleState.OpenChest();

        if (animator != null)
        {
            animator.SetTrigger("Open");
        }

        if (openAudioSource != null)
        {
            openAudioSource.Play();
        }

        if (chestFeedbackLight != null)
        {
            chestFeedbackLight.intensity = 4f;
        }

        keyPickupInteractable.UnlockKey();
    }

    public void UnlockChest()
    {
        isUnlocked = true;
    }
}