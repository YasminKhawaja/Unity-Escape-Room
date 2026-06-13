using UnityEngine;

public class TreasureChestController : MonoBehaviour
{
    [SerializeField] private Transform chestLid;
    [SerializeField] private GameObject keyObject;
    [SerializeField] private float openAngle = 160f;
    [SerializeField] private Vector3 openRotationAxis = new Vector3(1f, 0f, 0f);

    private bool isOpen;
    private Quaternion closedRotation;

    private void Start()
    {
        if (chestLid != null)
        {
            closedRotation = chestLid.localRotation;
        }

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

        if (chestLid != null)
        {
            Quaternion openRotation = closedRotation * Quaternion.Euler(openRotationAxis * openAngle);
            chestLid.localRotation = openRotation;
        }
        else
        {
            Debug.LogError("Chest Lid reference ontbreekt op TreasureChestController.");
        }

        if (keyObject != null)
        {
            keyObject.SetActive(true);
        }
        else
        {
            Debug.LogError("Key Object reference ontbreekt op TreasureChestController.");
        }
    }
}