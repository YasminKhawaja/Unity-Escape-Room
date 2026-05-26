using UnityEngine;

public class TreasureKistController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    [SerializeField] private RoomPuzzleState roomPuzzleState;
    [SerializeField] private KeyPickUpInteractable keyPickupInteractable;
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource openAudioSource;
    [SerializeField] private Light chestFeedbackLight;

    private bool isUnlocked;
    private bool isOpened;

   private void Start()
{
    if (animator != null)
    {
        animator.SetTrigger("Open");
    }
}
    public void Interact()
    {
        if (!isUnlocked || isOpened)
        {
            Debug.Log("Trigger Open wordt gezet");
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

