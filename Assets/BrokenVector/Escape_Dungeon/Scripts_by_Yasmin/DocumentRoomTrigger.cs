using UnityEngine;

public class DocumentRoomTrigger : MonoBehaviour
{
    [SerializeField] private FinalRoomCollectionController collectionController;
    [SerializeField] private string playerTag = "Player";

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(playerTag))
        {
            return;
        }

        collectionController.EnterDocumentRoom();
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag(playerTag))
        {
            return;
        }

        collectionController.ExitDocumentRoom();
    }
}