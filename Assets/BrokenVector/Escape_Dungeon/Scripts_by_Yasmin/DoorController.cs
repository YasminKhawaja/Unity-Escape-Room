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


using UnityEngine;
using UnityEngine.InputSystem;

public class DoorController : MonoBehaviour
{
    public string requiredKeyID;
    public Animator animator;
    public AudioSource audioSource;
    public AudioClip openSound;
    public HintSystem hintSystem;
    
    public UIInteraction ui;

    private bool isPlayerNear = false;
    private PlayerInventory inventory;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
            inventory = other.GetComponent<PlayerInventory>();
            ui.ShowInteractText("Druk op E om te openen");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
            ui.HideInteractText();
        }
    }

    private void Update()
    {
        if (isPlayerNear && Keyboard.current.eKey.wasPressedThisFrame)
        {
            TryOpenDoor();
        }
    }

    private void TryOpenDoor()
    {
        if (!inventory.HasKey(requiredKeyID))
        {
            ui.ShowInteractText("De deur is op slot — zoek de sleutel");
            hintSystem.ShowRiddle();
            return;
        }

        animator.SetTrigger("Open");
        audioSource.PlayOneShot(openSound);
        ui.HideInteractText();
    }
}
