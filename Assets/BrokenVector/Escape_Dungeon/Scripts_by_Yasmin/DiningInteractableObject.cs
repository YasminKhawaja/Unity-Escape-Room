using UnityEngine;

public class DiningInteractableObject : MonoBehaviour
{
    [SerializeField] private string promptText = "Druk op E om op te pakken.";

    public string PromptText => promptText;
}