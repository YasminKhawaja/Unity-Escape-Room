using UnityEngine;
using TMPro;

public class FinalDoorController : InteractableBase
{
    [Header("Final Door Settings")]
    [SerializeField] private string requiredKeyID = "KeyFinal";

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI endGameText;
    [SerializeField] private UIInteraction uiToHide;

    private bool hasFinished = false;

    private void Start()
    {
        if (endGameText != null)
            endGameText.gameObject.SetActive(false);
    }

    public override void Interact()
    {
        if (hasFinished)
            return;

        if (InventorySystem.HasKey(requiredKeyID))
        {
            FinishEscapeRoom();
        }
        else
        {
            if (uiToHide != null)
                uiToHide.ShowLockedMessage();

            Debug.Log("Laatste deur: speler heeft sleutel nog niet: " + requiredKeyID);
        }
    }

    private void FinishEscapeRoom()
    {
        hasFinished = true;

        Debug.Log("Escape room voltooid!");

        if (uiToHide != null)
            uiToHide.HideInteractPrompt();

        if (endGameText != null)
        {
            endGameText.text = "Proficiat! Je hebt de escape room voltooid!";
            endGameText.gameObject.SetActive(true);
        }
        else
        {
            Debug.LogWarning("EndGameText is niet ingevuld op FinalDoorController.", this);
        }
    }
}