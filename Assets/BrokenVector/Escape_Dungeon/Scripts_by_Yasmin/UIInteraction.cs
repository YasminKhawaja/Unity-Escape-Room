using UnityEngine;
using TMPro;

public class UIInteraction : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI interactText;
    [SerializeField] private TextMeshProUGUI lockedText;
    [SerializeField] private TextMeshProUGUI openText;

    private void Start()
    {
        if (interactText != null)
            interactText.gameObject.SetActive(false);

        if (lockedText != null)
            lockedText.gameObject.SetActive(false);

        if (openText != null)
            openText.gameObject.SetActive(false);
    }

    public void ShowInteractPrompt()
    {
        if (interactText == null)
            return;

        interactText.text = "Druk op E om te interageren";
        interactText.gameObject.SetActive(true);
    }

    public void HideInteractPrompt()
    {
        if (interactText == null)
            return;

        interactText.gameObject.SetActive(false);
    }

    public void ShowLockedMessage()
    {
        if (lockedText == null)
            return;

        lockedText.text = "De deur is op slot";
        lockedText.gameObject.SetActive(true);

        CancelInvoke(nameof(HideLockedMessage));
        Invoke(nameof(HideLockedMessage), 2f);
    }

    private void HideLockedMessage()
    {
        if (lockedText != null)
            lockedText.gameObject.SetActive(false);
    }

    public void ShowOpenMessage()
    {
        if (openText == null)
            return;

        openText.text = "De deur gaat open";
        openText.gameObject.SetActive(true);

        CancelInvoke(nameof(HideOpenMessage));
        Invoke(nameof(HideOpenMessage), 2f);
    }

    private void HideOpenMessage()
    {
        if (openText != null)
            openText.gameObject.SetActive(false);
    }
}