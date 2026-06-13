using UnityEngine;

public class DocumentRoomTrigger : MonoBehaviour
{
    [SerializeField] private FinalRoomCollectionController collectionController;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }

        if (collectionController != null)
        {
            collectionController.EnterDocumentRoom();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }

        if (collectionController != null)
        {
            collectionController.ExitDocumentRoom();
        }
    }
}