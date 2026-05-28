using UnityEngine;

public class TreasureKistController : MonoBehaviour
{
    [SerializeField] private RoomPuzzleState roomPuzzleState;
    [SerializeField] private KeyPickUpInteractable keyPickupInteractable;
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource openAudioSource;
    [SerializeField] private Light chestFeedbackLight;

    private bool isUnlocked;
    private bool isOpened;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            animator.SetTrigger("Open");
        }
    }

    public void Interact()
    {
        Debug.Log("Interact aangeroepen");

        if (!isUnlocked || isOpened)
        {
            Debug.Log("Kist is nog locked of al open");
            return;
        }

        isOpened = true;

        if (animator != null)
        {
            Debug.Log("Open trigger wordt gezet");
            animator.SetTrigger("Open");
        }
        else
        {
            Debug.Log("Animator is null");
        }

        if (roomPuzzleState != null)
        {
            roomPuzzleState.OpenChest();
        }

        if (openAudioSource != null)
        {
            openAudioSource.Play();
        }

        if (chestFeedbackLight != null)
        {
            chestFeedbackLight.intensity = 4f;
        }

        if (keyPickupInteractable != null)
        {
            keyPickupInteractable.UnlockKey();
        }
    }

    public void UnlockChest()
    {
        isUnlocked = true;
        Debug.Log("Kist unlocked");
    }
}