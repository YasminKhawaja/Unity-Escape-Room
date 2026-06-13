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

    private void Start()
    {
        UpdateProgressText();
    }

    public void CollectItem(CollectibleItem collectedItem)
    {
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

        UpdateProgressText();
        CheckIfAllItemsCollected();
    }

    public void ShowPrompt(string promptMessage)
    {
        if (interactionPromptText != null)
        {
            interactionPromptText.text = promptMessage;
        }
    }

    public void ShowDefaultPrompt()
    {
        UpdateProgressText();
    }

    private void CheckIfAllItemsCollected()
    {
        if (hasOpenedChest)
        {
            return;
        }

        if (hasPaper03 && hasBook06 && hasPaper01)
        {
            hasOpenedChest = true;

            if (interactionPromptText != null)
            {
                interactionPromptText.text = "Je hebt alle documenten verzameld. De schatkist opent.";
            }

            treasureChestController.OpenChest();
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
}