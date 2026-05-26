using UnityEngine;

public class PlayerRaycastInteraction : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    [SerializeField] private float interactDistance = 3f;
    [SerializeField] private KeyCode interactKey = KeyCode.E;
    [SerializeField] private SequencePuzzleController sequencePuzzleController;
    [SerializeField] private LayerMask interactionLayers = ~0;

    private InteractableObject currentInteractable;

    private void Update()
    {
        if (!sequencePuzzleController.IsPuzzleActive || sequencePuzzleController.IsSolved)
        {
            currentInteractable = null;
            return;
        }

        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactDistance, interactionLayers))
        {
            InteractableObject interactableObject = hit.collider.GetComponent<InteractableObject>();

            if (interactableObject != null)
            {
                currentInteractable = interactableObject;
                sequencePuzzleController.ShowHoverPrompt(interactableObject.PromptText);

                if (Input.GetKeyDown(interactKey))
                {
                    currentInteractable.Interact();
                }

                return;
            }
        }

        currentInteractable = null;
        sequencePuzzleController.ShowDefaultPuzzlePrompt();
    }
}