using UnityEngine;

public abstract class InteractableObject : MonoBehaviour
{
    [SerializeField] private string promptText = "Druk op E om op te pakken.";

    public string PromptText => promptText;

    public abstract void Interact();
}