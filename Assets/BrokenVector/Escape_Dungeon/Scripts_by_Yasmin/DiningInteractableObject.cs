using UnityEngine;

public abstract class DiningInteractableObject : MonoBehaviour
{
    [SerializeField] private string promptText = "Druk op E";

    public string PromptText => promptText;

    public abstract void Interact(DiningPlayerInteraction playerInteraction);
}