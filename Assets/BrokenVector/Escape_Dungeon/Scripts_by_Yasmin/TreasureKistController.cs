// using UnityEngine;

// public class TreasureKistController : InteractableBase
// {
//     [Header("References")]
//     [SerializeField] private RoomPuzzleState roomPuzzleState;
//     [SerializeField] private Animator animator;
//     [SerializeField] private AudioSource openAudioSource;
//     [SerializeField] private Light chestFeedbackLight;

//     [Header("Settings")]
//     [SerializeField] private string openTriggerName = "Open";
//     [SerializeField] private float openedLightIntensity = 4f;
//     [SerializeField] private bool startUnlocked = true;

//     private bool isOpened;

//     public override void Interact()
//     {
//         Debug.Log("Interact met kist", this);

//         if (isOpened)
//         {
//             Debug.Log("Kist is al open.", this);
//             return;
//         }

//         OpenChest();
//     }

//     private void OpenChest()
//     {
//         isOpened = true;

//         Debug.Log("Kist gaat open", this);

//         if (animator != null)
//             animator.SetTrigger(openTriggerName);

//         if (openAudioSource != null)
//             openAudioSource.Play();

//         if (chestFeedbackLight != null)
//             chestFeedbackLight.intensity = openedLightIntensity;

//         if (roomPuzzleState != null)
//             roomPuzzleState.OpenChest();
//     }

//     public bool IsOpened() => isOpened;
// }


// using UnityEngine;

// public class TreasureKistController : InteractableBase
// {
//     [Header("References")]
//     [SerializeField] private Animator lidAnimator;
//     [SerializeField] private GameObject keyObject;
//     [SerializeField] private AudioSource openAudioSource;
//     [SerializeField] private Light chestFeedbackLight;

//     [Header("Settings")]
//     [SerializeField] private string openTriggerName = "Open";
//     [SerializeField] private float openedLightIntensity = 4f;

//     private bool isOpened = false;

//     private void Start()
//     {
//         if (keyObject != null)
//             keyObject.SetActive(false);
//     }

//     public override void Interact()
//     {
//         Debug.Log("E gedrukt op kist: " + gameObject.name);

//         if (isOpened)
//         {
//             Debug.Log("Kist is al open.");
//             return;
//         }

//         OpenChest();
//     }

//     private void OpenChest()
//     {
//         isOpened = true;

//         Debug.Log("Kist opent: " + gameObject.name);

//         if (lidAnimator != null)
//         {
//             lidAnimator.ResetTrigger(openTriggerName);
//             lidAnimator.SetTrigger(openTriggerName);
//         }
//         else
//         {
//             Debug.LogWarning("Lid Animator is niet ingevuld op de kist.", this);
//         }

//         if (openAudioSource != null)
//             openAudioSource.Play();

//         if (chestFeedbackLight != null)
//             chestFeedbackLight.intensity = openedLightIntensity;

//         if (keyObject != null)
//             keyObject.SetActive(true);
//     }
// }


using UnityEngine;

public class TreasureKistController : InteractableBase
{
    [Header("References")]
    [SerializeField] private Animator lidAnimator;
    [SerializeField] private GameObject keyObject;
    [SerializeField] private AudioSource openAudioSource;

    [Header("Settings")]
    [SerializeField] private string openTriggerName = "Open";

    private bool isOpened = false;

    private void Start()
    {
        if (keyObject != null)
            keyObject.SetActive(false);
        else
            Debug.LogWarning("Key Object is niet ingevuld op de kist.", this);
    }

    public override void Interact()
    {
        Debug.Log("Interact op KIST: " + gameObject.name, this);

        if (isOpened)
        {
            Debug.Log("Kist is al open.", this);
            return;
        }

        OpenChest();
    }

    private void OpenChest()
    {
        isOpened = true;

        Debug.Log("Kist opent. Trigger wordt gestuurd: " + openTriggerName, this);

        if (lidAnimator == null)
        {
            Debug.LogError("Lid Animator is NIET ingevuld op TreasureKistController.", this);
            return;
        }

        lidAnimator.ResetTrigger(openTriggerName);
        lidAnimator.SetTrigger(openTriggerName);

        if (openAudioSource != null)
            openAudioSource.Play();

        if (keyObject != null)
            keyObject.SetActive(true);
    }
}