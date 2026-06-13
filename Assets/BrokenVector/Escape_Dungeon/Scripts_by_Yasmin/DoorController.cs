// using UnityEngine;

// public class DoorController : MonoBehaviour
// {
//     public Animator animator;
//     public AudioSource audioSource;
//     public AudioClip openSound;
//     public HintSystem hintSystem;

//     public bool playerHasKey = false;
//     private bool isPlayerNear = false;

//     private void Update()
//     {
//         if (Input.GetKeyDown(KeyCode.E))
//         {
//             Debug.Log("E key pressed");

//             if (isPlayerNear)
//             {
//                 Debug.Log("Player is near the door");
//                 TryOpenDoor();
//             }
//             else
//             {
//                 Debug.Log("Player is NOT near the door");
//             }
//         }
//     }

//     private void TryOpenDoor()
//     {
//         if (!playerHasKey)
//         {
//             Debug.Log("Player has NO key");
//             hintSystem.ShowRiddle();
//             return;
//         }

//         Debug.Log("Player HAS key — opening door");
//         animator.SetTrigger("Open");

//         if (openSound != null)
//             audioSource.PlayOneShot(openSound);
//     }

//     private void OnTriggerEnter(Collider other)
//     {
//         if (other.CompareTag("Player"))
//         {
//             Debug.Log("Player entered trigger");
//             isPlayerNear = true;
//         }
//     }

//     private void OnTriggerExit(Collider other)
//     {
//         if (other.CompareTag("Player"))
//         {
//             Debug.Log("Player exited trigger");
//             isPlayerNear = false;
//         }
//     }
// }


// using UnityEngine;
// using UnityEngine.InputSystem;

// public class DoorController : MonoBehaviour
// {
//     public string requiredKeyID;
//     public Animator animator;
//     public AudioSource audioSource;
//     public AudioClip openSound;
//     public HintSystem hintSystem;
    
//     public UIInteraction ui;

//     private bool isPlayerNear = false;
//     private PlayerInventory inventory;

//     private void OnTriggerEnter(Collider other)
//     {
//         if (other.CompareTag("Player"))
//         {
//             isPlayerNear = true;
//             inventory = other.GetComponent<PlayerInventory>();
//             ui.ShowInteractText("Druk op E om te openen");
//         }
//     }

//     private void OnTriggerExit(Collider other)
//     {
//         if (other.CompareTag("Player"))
//         {
//             isPlayerNear = false;
//             ui.HideInteractText();
//         }
//     }

//     private void Update()
//     {
//         if (isPlayerNear && Keyboard.current.eKey.wasPressedThisFrame)
//         {
//             TryOpenDoor();
//         }
//     }

//     private void TryOpenDoor()
//     {
//         if (!inventory.HasKey(requiredKeyID))
//         {
//             ui.ShowInteractText("De deur is op slot — zoek de sleutel");
//             hintSystem.ShowRiddle();
//             return;
//         }

//         animator.SetTrigger("Open");
//         audioSource.PlayOneShot(openSound);
//         ui.HideInteractText();
//     }
// }


// using UnityEngine;

// public class DoorController : InteractableBase
// {
//     [Header("Door Settings")]
//     [SerializeField] private string requiredKeyID = "Key";
//     [SerializeField] private Animator animator;
//     [SerializeField] private AudioSource audioSource;
//     [SerializeField] private AudioClip openSound;

//     [Header("Hint System")]
//     [SerializeField] private HintSystemMulti hintSystem;
//     [SerializeField] private int hintIndex;

//     [Header("UI")]
//     [SerializeField] private UIInteraction ui;

//     private bool isOpen = false;

//     public override void Interact()
//     {
//         TryOpenDoor();
//     }

//     private void TryOpenDoor()
//     {
//         if (isOpen)
//         {
//             Debug.Log("Deur is al open.");
//             return;
//         }

//         if (InventorySystem.HasKey(requiredKeyID))
//         {
//             OpenDoor();
//         }
//         else
//         {
//             Debug.Log("Geen sleutel: " + requiredKeyID);

//             if (hintSystem != null)
//                 hintSystem.SetDoorIndex(hintIndex);

//             if (ui != null)
//                 ui.ShowLockedMessage();
//         }
//     }

//     private void OpenDoor()
//     {
//         isOpen = true;

//         Debug.Log("Deur opent met sleutel: " + requiredKeyID);

//         if (animator != null)
//             animator.SetTrigger("Open");
//         else
//             Debug.LogWarning("Animator ontbreekt op deur.");

//         if (audioSource != null && openSound != null)
//             audioSource.PlayOneShot(openSound);

//         if (ui != null)
//             ui.ShowOpenMessage();
//     }
// }



using UnityEngine;

public class DoorController : InteractableBase
{
    [Header("Door Settings")]
    [SerializeField] private string requiredKeyID = "Key";
    [SerializeField] private Animator animator;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip openSound;

    [Header("Hint System")]
    [SerializeField] private HintSystemMulti hintSystem;
    [SerializeField] private int hintIndex;

    [Header("UI")]
    [SerializeField] private UIInteraction ui;

    private bool isOpen = false;

    public override void Interact()
    {
        Debug.Log("DoorController Interact gestart op: " + gameObject.name);
        TryOpenDoor();
    }

    private void TryOpenDoor()
    {
        if (isOpen)
        {
            Debug.Log("Deur is al open: " + gameObject.name);
            return;
        }

        Debug.Log("Deze deur vraagt sleutel: " + requiredKeyID);

        if (InventorySystem.HasKey(requiredKeyID))
        {
            Debug.Log("Sleutel gevonden. Deur mag open.");
            OpenDoor();
        }
        else
        {
            Debug.LogWarning("Je hebt deze sleutel NIET: " + requiredKeyID);

            if (hintSystem != null)
                hintSystem.SetDoorIndex(hintIndex);
            else
                Debug.LogWarning("HintSystem is niet ingevuld op " + gameObject.name);

            if (ui != null)
                ui.ShowLockedMessage();
            else
                Debug.LogWarning("UI is niet ingevuld op " + gameObject.name);
        }
    }

    private void OpenDoor()
    {
        isOpen = true;

        Debug.Log("OpenDoor gestart op: " + gameObject.name);

        if (animator != null)
        {
            animator.SetTrigger("Open");
            Debug.Log("Animator trigger Open verstuurd.");
        }
        else
        {
            Debug.LogWarning("Animator ontbreekt op deur: " + gameObject.name);
        }

        if (audioSource != null && openSound != null)
        {
            audioSource.PlayOneShot(openSound);
        }

        if (ui != null)
        {
            ui.ShowOpenMessage();
        }
    }
}