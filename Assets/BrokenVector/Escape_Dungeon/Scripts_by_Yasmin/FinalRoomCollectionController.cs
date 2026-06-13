using UnityEngine;
using TMPro;

public class FinalRoomCollectionController : MonoBehaviour
{
    [SerializeField] private TreasureChestController treasureChestController;
    [SerializeField] private TMP_Text interactionPromptText;

    private bool hasPaper03;
    private bool hasBook06;
    private bool hasPaper01;
    private bool hasOpenedChest;
    private bool isPlayerInDocumentRoom;

    private void Start()
    {
        HidePrompt();
    }

    public void EnterDocumentRoom()
    {
        isPlayerInDocumentRoom = true;
        UpdateProgressText();
    }

    public void ExitDocumentRoom()
    {
        isPlayerInDocumentRoom = false;
        HidePrompt();
    }

    public void CollectItem(CollectibleItem collectedItem)
    {
        Debug.Log("Collected item id: " + collectedItem.ItemId);

        if (collectedItem.ItemId == "paper03")
        {
            hasPaper03 = true;
        }
        else if (collectedItem.ItemId == "book06")
        {
            hasBook06 = true;
        }
        else if (collectedItem.ItemId == "paper01")
        {
            hasPaper01 = true;
        }
        else
        {
            Debug.LogWarning("Unknown item id: " + collectedItem.ItemId);
        }

        Debug.Log("Status -> paper03: " + hasPaper03 + ", book06: " + hasBook06 + ", paper01: " + hasPaper01);

        if (isPlayerInDocumentRoom)
        {
            UpdateProgressText();
        }

        CheckIfAllItemsCollected();
    }

    public void ShowPrompt(string promptMessage)
    {
        if (!isPlayerInDocumentRoom)
        {
            return;
        }

        if (interactionPromptText != null)
        {
            interactionPromptText.text = promptMessage;
        }
    }

    public void ShowDefaultPrompt()
    {
        if (!isPlayerInDocumentRoom)
        {
            return;
        }

        UpdateProgressText();
    }

    private void CheckIfAllItemsCollected()
    {
        Debug.Log("Checking all items collected...");

        if (hasOpenedChest)
        {
            Debug.Log("Chest already opened.");
            return;
        }

        if (hasPaper03 && hasBook06 && hasPaper01)
        {
            Debug.Log("All items collected. Opening chest.");
            hasOpenedChest = true;

            if (interactionPromptText != null && isPlayerInDocumentRoom)
            {
                interactionPromptText.text = "Je hebt alle documenten verzameld. De schatkist opent.";
            }

            if (treasureChestController != null)
            {
                treasureChestController.OpenChest();
            }
            else
            {
                Debug.LogError("TreasureChestController reference is missing.");
            }
        }
    }

    private void UpdateProgressText()
    {
        if (interactionPromptText == null)
        {
            return;
        }

        int collectedCount = 0;

        if (hasPaper03)
        {
            collectedCount++;
        }

        if (hasBook06)
        {
            collectedCount++;
        }

        if (hasPaper01)
        {
            collectedCount++;
        }

        interactionPromptText.text = "Verzamel de 3 documenten: " + collectedCount + "/3";
    }

    private void HidePrompt()
    {
        if (interactionPromptText != null)
        {
            interactionPromptText.text = string.Empty;
        }
    }
}