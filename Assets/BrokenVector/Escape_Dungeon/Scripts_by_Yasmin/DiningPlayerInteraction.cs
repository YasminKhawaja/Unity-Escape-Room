using UnityEngine;

public class DiningPlayerInteraction : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    [SerializeField] private float interactDistance = 3f;
    [SerializeField] private LayerMask interactionLayers = ~0;
    [SerializeField] private DiningTablePuzzleController puzzleController;

    private void Update()
    {
        HandleRaycastInteraction();
    }

    private void HandleRaycastInteraction()
    {
        if (playerCamera == null || puzzleController == null)
        {
            return;
        }

        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, interactDistance, interactionLayers))
        {
            DiningPickupItem pickupItem = hit.collider.GetComponent<DiningPickupItem>();

            if (pickupItem != null)
            {
                puzzleController.ShowPrompt(pickupItem.PromptText);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    puzzleController.RegisterCollectedItem(pickupItem.ItemId);
                    pickupItem.gameObject.SetActive(false);
                }
            }
        }
    }
}