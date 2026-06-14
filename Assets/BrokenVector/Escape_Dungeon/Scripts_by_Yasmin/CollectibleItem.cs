// using UnityEngine;

// public class CollectibleItem : InteractableObject
// {
//     [SerializeField] private string itemId;
//     [SerializeField] private FinalRoomCollectionController collectionController;

//     public string ItemId => itemId;

//     public override void Interact()
//     {
//         Debug.Log("CollectibleItem Interact called for: " + itemId);

//         if (collectionController != null)
//         {
//             collectionController.CollectItem(this);
//         }
//         else
//         {
//             Debug.LogError("CollectionController is missing on item: " + itemId);
//         }

//         gameObject.SetActive(false);
//     }
// }

using UnityEngine;

public class CollectibleItem : InteractableBase
{
    [SerializeField] private string itemId;
    [SerializeField] private FinalRoomCollectionController collectionController;

    public string ItemId => itemId;

    public override void Interact()
    {
        Debug.Log("CollectibleItem Interact called for: " + itemId, this);

        if (collectionController != null)
        {
            collectionController.CollectItem(this);
        }
        else
        {
            Debug.LogError("CollectionController is missing on item: " + itemId, this);
        }

        gameObject.SetActive(false);
    }
}