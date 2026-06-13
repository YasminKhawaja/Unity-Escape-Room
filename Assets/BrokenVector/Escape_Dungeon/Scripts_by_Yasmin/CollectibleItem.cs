using UnityEngine;

public class CollectibleItem : InteractableObject
{
    [SerializeField] private string itemId;
    [SerializeField] private FinalRoomCollectionController collectionController;

    public string ItemId => itemId;

    public override void Interact()
    {
        collectionController.CollectItem(this);
        gameObject.SetActive(false);
    }
}