using UnityEngine;
using TMPro;

public class HintSystem : MonoBehaviour
{
    public TextMeshProUGUI riddleText;
    public TextMeshProUGUI hintText;

    private void Start()
    {
        riddleText.gameObject.SetActive(false);
        hintText.gameObject.SetActive(false);
        
        FindObjectOfType<UIInteraction>().ShowHintControls();
    }

    

    public void ShowRiddle()
    {
        riddleText.text = "Waar het vuur nooit slaapt, bewaakt een oude vlam wat jij zoekt.";
        riddleText.gameObject.SetActive(true);
        Invoke(nameof(HideRiddle), 4f);
    }

    public void ShowHint()
    {
        hintText.text = "De sleutel ligt bij een warmtebron.";
        hintText.gameObject.SetActive(true);
        Invoke(nameof(HideHint), 3f);
    }

    private void HideRiddle() => riddleText.gameObject.SetActive(false);
    private void HideHint() => hintText.gameObject.SetActive(false);

    private void Update()
    {
         if (Input.GetKeyDown(KeyCode.H))
        ShowHint();

    if (Input.GetKeyDown(KeyCode.R))
        ShowRiddle();

    if (Input.GetKeyDown(KeyCode.T))
        ShowHint(); // testknop

    }
}