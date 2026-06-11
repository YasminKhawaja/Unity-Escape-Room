using UnityEngine;

public class TreasureKistController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private RoomPuzzleState roomPuzzleState;
    [SerializeField] private KeyPickUpInteractable keyPickupInteractable;
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource openAudioSource;
    [SerializeField] private Light chestFeedbackLight;

    [Header("Settings")]
    [SerializeField] private string openTriggerName = "Open";
    [SerializeField] private float openedLightIntensity = 4f;
    [SerializeField] private bool startUnlocked = false;

    private bool isUnlocked;
    private bool isOpened;

    private void Awake()
    {
        isUnlocked = startUnlocked;
    }

    private void Start()
    {
        Debug.Log("TreasureKistController Start werkt", this);

        if (animator == null)
        {
            Debug.LogWarning("TreasureKistController: Animator reference ontbreekt.", this);
            return;
        }

        animator.ResetTrigger(openTriggerName);
        animator.SetTrigger(openTriggerName);
        Debug.Log("Trigger gezet in Start()", this);
    }

    public void Interact()
    {
        Debug.Log("Interact aangeroepen", this);

        if (!isUnlocked)
        {
            Debug.Log("Chest is nog locked.", this);
            return;
        }

        if (isOpened)
        {
            Debug.Log("Chest is al geopend.", this);
            return;
        }

        OpenChest();
    }

    public void UnlockChest()
    {
        isUnlocked = true;
        Debug.Log("Chest unlocked.", this);
    }

    private void OpenChest()
    {
        Debug.Log("OpenChest aangeroepen", this);
        isOpened = true;

        if (animator != null)
        {
            Debug.Log("Open trigger gezet op animator.");
            animator.ResetTrigger(openTriggerName);
            animator.SetTrigger(openTriggerName);
            Debug.Log("Open trigger gezet op animator.", this);
        }
        else
        {
            Debug.LogWarning("Animator is NULL", this);
        }

        if (openAudioSource != null)
        {
            openAudioSource.Play();
        }

        if (chestFeedbackLight != null)
        {
            chestFeedbackLight.intensity = openedLightIntensity;
        }

        if (roomPuzzleState != null)
        {
            roomPuzzleState.OpenChest();
        }

        if (keyPickupInteractable != null)
        {
            keyPickupInteractable.UnlockKey();
        }
    }

    public bool IsUnlocked()
    {
        return isUnlocked;
    }

    public bool IsOpened()
    {
        return isOpened;
    }
}