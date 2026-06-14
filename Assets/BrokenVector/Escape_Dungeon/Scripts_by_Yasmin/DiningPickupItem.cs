using UnityEngine;

public class DiningPickupItem : MonoBehaviour
{
    [SerializeField] private string itemId;
    [SerializeField] private string promptText = "Druk op E om op te pakken.";

    public string ItemId => itemId;
    public string PromptText => promptText;
}