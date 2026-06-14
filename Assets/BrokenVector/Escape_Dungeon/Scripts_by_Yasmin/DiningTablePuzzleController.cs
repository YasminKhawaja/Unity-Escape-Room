using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DiningTablePuzzleController : MonoBehaviour
{
    [SerializeField] private GameObject keyDining;
    [SerializeField] private TMP_Text interactionPromptText;

    private readonly string[] requiredItems = { "inkpot", "scale", "sandglass" };
    private readonly HashSet<string> collectedItems = new HashSet<string>();

    private string roomMessage = "";

    private void Start()
    {
        if (keyDining != null)
        {
            keyDining.SetActive(false);
        }

        if (interactionPromptText != null)
        {
            interactionPromptText.text = "";
        }
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

    public void SetRoomMessage(string message)
    {
        roomMessage = message;
        ShowPrompt(roomMessage);
    }

    public void RestoreRoomMessage()
    {
        ShowPrompt(roomMessage);
    }

    public void RegisterCollectedItem(string itemId)
    {
        if (string.IsNullOrWhiteSpace(itemId))
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

            SetRoomMessage("Je hebt alles gevonden. De sleutel is verschenen.");
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