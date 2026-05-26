using UnityEngine;

public abstract class InteractableObject : MonoBehaviour
{
    [SerializeField] private string interactionPrompt = "Interact";

    public string InteractionPrompt => interactionPrompt;

    public abstract void Interact();
}
