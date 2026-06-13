using TMPro;
using UnityEngine;

public class FinalRoomCollectionController : MonoBehaviour
{
    [SerializeField] private GameObject rewardKeyObject;
    [SerializeField] private TMP_Text interactionPromptText;

    private bool hasPaper03;
    private bool hasBook06;
    private bool hasPaper01;
    private bool rewardShown;
    private bool isPlayerInDocumentRoom;

    private void Start()
    {
        if (rewardKeyObject != null)
        {
            rewardKeyObject.SetActive(false);
        }

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
            Debug.LogWarning("Onbekende itemId: " + collectedItem.ItemId);
        }

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
        if (rewardShown)
        {
            return;
        }

        if (hasPaper03 && hasBook06 && hasPaper01)
        {
            rewardShown = true;

            if (rewardKeyObject != null)
            {
                rewardKeyObject.SetActive(true);
            }
            else
            {
                Debug.LogError("Reward Key Object ontbreekt in FinalRoomCollectionController.");
            }

            if (interactionPromptText != null && isPlayerInDocumentRoom)
            {
                interactionPromptText.text = "Je hebt alle documenten gevonden. De sleutel is verschenen op de tafel.";
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

        interactionPromptText.text = "Verzamel de 3 documenten. Documenten " + collectedCount + "/3";
    }

    private void HidePrompt()
    {
        if (interactionPromptText != null)
        {
            interactionPromptText.text = string.Empty;
        }
    }
}