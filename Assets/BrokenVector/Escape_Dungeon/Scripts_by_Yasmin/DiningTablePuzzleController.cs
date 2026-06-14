using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DiningTablePuzzleController : MonoBehaviour
{
    [SerializeField] private GameObject keyDining;
    [SerializeField] private TMP_Text interactionPromptText;

    private readonly string[] requiredItems = { "inkpot", "scale", "sandglass" };
    private HashSet<string> collectedItems = new HashSet<string>();

    private void Start()
    {
        if (keyDining != null)
        {
            keyDining.SetActive(false);
        }

        ClearPrompt();
    }

    public void ShowPrompt(string message)
    {
        if (interactionPromptText != null)
        {
            interactionPromptText.text = message;
        }
    }

    public void ClearPrompt()
    {
        if (interactionPromptText != null)
        {
            interactionPromptText.text = "";
        }
    }

    public void RegisterCollectedItem(string itemId)
    {
        if (string.IsNullOrEmpty(itemId))
        {
            return;
        }

        collectedItems.Add(itemId);

        if (AllItemsCollected())
        {
            if (keyDining != null)
            {
                keyDining.SetActive(true);
            }

            ShowPrompt("Je hebt alles gevonden. De sleutel is verschenen.");
        }
    }

    private bool AllItemsCollected()
    {
        foreach (string requiredItem in requiredItems)
        {
            if (!collectedItems.Contains(requiredItem))
            {
                return false;
            }
        }

        return true;
    }
}