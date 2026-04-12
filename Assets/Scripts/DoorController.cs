using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private Animator doorAnimator;
    [SerializeField] private string openParameter = "Open";

    private bool isOpen = false;

    private void OpenDoor()
    {
        if (isOpen) return;

        isOpen = true;
        doorAnimator.SetTrigger(openParameter);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OpenDoor();
        }
    }
}
