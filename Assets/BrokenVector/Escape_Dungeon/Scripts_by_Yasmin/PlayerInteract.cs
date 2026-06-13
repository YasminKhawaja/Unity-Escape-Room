// using UnityEngine;

// public class PlayerInteract : MonoBehaviour
// {
//     [SerializeField] private float interactDistance = 3f;
//     [SerializeField] private LayerMask interactLayer;
//     [SerializeField] private UIInteraction ui;

//     private Camera cam;

//     private void Start()
//     {
//         cam = Camera.main;

//         if (cam == null)
//             Debug.LogError("Geen Main Camera gevonden. Zet je camera tag op MainCamera.");

//         if (ui == null)
//             Debug.LogError("UIInteraction is niet ingevuld op PlayerInteract.");
//     }

//     private void Update()
//     {
//         if (cam == null || ui == null)
//             return;

//         Ray ray = new Ray(cam.transform.position, cam.transform.forward);

//         if (Physics.Raycast(ray, out RaycastHit hit, interactDistance, interactLayer))
//         {
//             InteractableBase interactable = hit.collider.GetComponentInParent<InteractableBase>();

//             if (interactable != null)
//             {
//                 ui.ShowInteractPrompt();

//                 if (Input.GetKeyDown(KeyCode.E))
//                 {
//                     Debug.Log("Interact met: " + interactable.gameObject.name);
//                     interactable.Interact();
//                 }

//                 return;
//             }
//         }

//         ui.HideInteractPrompt();
//     }
// }



using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private float interactDistance = 5f;
    [SerializeField] private LayerMask interactLayer;
    [SerializeField] private UIInteraction ui;

    private Camera cam;

    private void Start()
    {
        cam = Camera.main;

        if (cam == null)
            Debug.LogError("GEEN MAIN CAMERA GEVONDEN. Zet je camera tag op MainCamera.");

        if (ui == null)
            Debug.LogError("UIInteraction is NIET ingevuld op PlayerInteract.");
    }

    private void Update()
    {
        if (cam == null || ui == null)
            return;

        Ray ray = new Ray(cam.transform.position, cam.transform.forward);

        Debug.DrawRay(cam.transform.position, cam.transform.forward * interactDistance, Color.red);

        if (Physics.Raycast(ray, out RaycastHit hit, interactDistance, interactLayer))
        {
            Debug.Log("Raycast raakt: " + hit.collider.gameObject.name);

            InteractableBase interactable = hit.collider.GetComponentInParent<InteractableBase>();

            if (interactable != null)
            {
                ui.ShowInteractPrompt();

                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("E gedrukt op interactable: " + interactable.gameObject.name);
                    interactable.Interact();
                }

                return;
            }
            else
            {
                Debug.LogWarning("Geraakt object heeft GEEN InteractableBase: " + hit.collider.gameObject.name);
            }
        }

        ui.HideInteractPrompt();
    }
}