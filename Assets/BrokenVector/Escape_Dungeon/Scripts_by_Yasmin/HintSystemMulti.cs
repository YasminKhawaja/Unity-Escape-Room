using UnityEngine;
using TMPro;

public class HintSystemMulti : MonoBehaviour
{
    [System.Serializable]
    public class HintSet
    {
        [TextArea]
        public string riddle;

        [TextArea]
        public string hint;
    }

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI riddleText;
    [SerializeField] private TextMeshProUGUI hintText;

    [Header("Hints per deur")]
    [SerializeField] private HintSet[] hintSets;

    private int currentDoorIndex = 0;

    private void Start()
    {
        if (riddleText != null)
            riddleText.gameObject.SetActive(false);
        else
            Debug.LogWarning("HintSystemMulti: riddleText is niet ingevuld.", this);

        if (hintText != null)
            hintText.gameObject.SetActive(false);
        else
            Debug.LogWarning("HintSystemMulti: hintText is niet ingevuld.", this);
    }

    public void SetDoorIndex(int index)
    {
        if (hintSets == null || hintSets.Length == 0)
        {
            Debug.LogWarning("HintSystemMulti: hintSets is leeg.", this);
            return;
        }

        if (index < 0 || index >= hintSets.Length)
        {
            Debug.LogWarning("HintSystemMulti: Ongeldige hint index: " + index, this);
            return;
        }

        currentDoorIndex = index;
        Debug.Log("Hint index ingesteld op: " + currentDoorIndex, this);
    }

    public void ShowRiddle()
    {
        if (!IsValidHintIndex())
            return;

        if (riddleText == null)
            return;

        riddleText.text = hintSets[currentDoorIndex].riddle;
        riddleText.gameObject.SetActive(true);

        CancelInvoke(nameof(HideRiddle));
        Invoke(nameof(HideRiddle), 4f);
    }

    public void ShowHint()
    {
        if (!IsValidHintIndex())
            return;

        if (hintText == null)
            return;

        hintText.text = hintSets[currentDoorIndex].hint;
        hintText.gameObject.SetActive(true);

        CancelInvoke(nameof(HideHint));
        Invoke(nameof(HideHint), 3f);
    }

    private bool IsValidHintIndex()
    {
        if (hintSets == null || hintSets.Length == 0)
        {
            Debug.LogWarning("HintSystemMulti: geen hints ingesteld.", this);
            return false;
        }

        if (currentDoorIndex < 0 || currentDoorIndex >= hintSets.Length)
        {
            Debug.LogWarning("HintSystemMulti: currentDoorIndex bestaat niet: " + currentDoorIndex, this);
            return false;
        }

        return true;
    }

    private void HideRiddle()
    {
        if (riddleText != null)
            riddleText.gameObject.SetActive(false);
    }

    private void HideHint()
    {
        if (hintText != null)
            hintText.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
            ShowHint();

        if (Input.GetKeyDown(KeyCode.R))
            ShowRiddle();
    }
}