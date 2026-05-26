using UnityEngine;
using System.Collections;

public class TreasureChestController : MonoBehaviour
{
    [Header("Chest References")]
    [SerializeField] private Transform chestLid;
    [SerializeField] private GameObject keyObject;

    [Header("Open Settings")]
    [SerializeField] private float openAngle = -110f;
    [SerializeField] private float openDuration = 1.2f;

    private Quaternion closedRotation;
    private Quaternion openRotation;
    private bool isOpen;

    private void Awake()
    {
        closedRotation = chestLid.localRotation;
        openRotation = closedRotation * Quaternion.Euler(openAngle, 0f, 0f);

        if (keyObject != null)
        {
            keyObject.SetActive(false);
        }
    }

    public void OpenChest()
    {
        if (isOpen)
        {
            return;
        }

        isOpen = true;
        StartCoroutine(OpenChestRoutine());
    }

    private IEnumerator OpenChestRoutine()
    {
        float elapsedTime = 0f;

        while (elapsedTime < openDuration)
        {
            elapsedTime += Time.deltaTime;
            float progress = elapsedTime / openDuration;
            float easedProgress = Mathf.SmoothStep(0f, 1f, progress);

            chestLid.localRotation = Quaternion.Slerp(closedRotation, openRotation, easedProgress);
            yield return null;
        }

        chestLid.localRotation = openRotation;

        if (keyObject != null)
        {
            keyObject.SetActive(true);
        }
    }
}
