using UnityEngine;

public abstract class InteractableBase : MonoBehaviour
{
    [SerializeField] private string promptText = "Interact";

    public string PromptText => promptText;

    public abstract void Interact();
}
