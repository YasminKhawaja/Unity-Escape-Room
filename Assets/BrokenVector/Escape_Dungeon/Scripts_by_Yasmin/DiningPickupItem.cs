using UnityEngine;

public class DiningPickupItem : DiningInteractableObject
{
    [SerializeField] private string itemId;

    public string ItemId => itemId;
}