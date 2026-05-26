using UnityEngine;
using TMPro;

public class HudUIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI messageText;

    public void ShowMessage(string message)
    {
        messageText.text = message;
    }
}
