using UnityEngine;
using TMPro;

public class UIInteraction : MonoBehaviour
{
    public TextMeshProUGUI interactText;

    private void Start()
    {
        interactText.gameObject.SetActive(false);
    }

    public void ShowInteractText(string message)
    {
        interactText.text = message;
        interactText.gameObject.SetActive(true);
    }

    public void HideInteractText()
    {
        interactText.gameObject.SetActive(false);
    }

    public void ShowHintControls()
{
    ShowInteractText("Druk op R voor raadsel — H voor hint");
}

}

