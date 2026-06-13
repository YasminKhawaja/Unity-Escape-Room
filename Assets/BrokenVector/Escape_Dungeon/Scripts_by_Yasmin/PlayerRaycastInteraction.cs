using UnityEngine;

public class PlayerRaycastInteraction : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    [SerializeField] private float interactDistance = 3f;
    [SerializeField] private KeyCode interactKey = KeyCode.E;
    [SerializeField] private LayerMask interactionLayers = ~0;
    [SerializeField] private FinalRoomCollectionController collectionController;

    private void Update()
    {
        if (playerCamera == null || collectionController == null)
        {
            return;
        }

        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactDistance, interactionLayers))
        {
            InteractableObject interactableObject = hit.collider.GetComponentInParent<InteractableObject>();

            if (interactableObject != null)
            {
                collectionController.ShowPrompt(interactableObject.PromptText);

                if (Input.GetKeyDown(interactKey))
                {
                    interactableObject.Interact();
                }

                return;
            }
        }

        collectionController.ShowDefaultPrompt();
    }
}