using UnityEngine;

public class CollectibleItem : InteractableObject
{
    [SerializeField] private string itemId;
    [SerializeField] private FinalRoomCollectionController collectionController;

    public string ItemId => itemId;

    public override void Interact()
    {
        if (collectionController == null)
        {
            Debug.LogError("CollectionController ontbreekt op: " + gameObject.name);
            return;
        }

        collectionController.CollectItem(this);
        gameObject.SetActive(false);
    }
}