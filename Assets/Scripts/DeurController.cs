using UnityEngine;

public class DeurController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private bool isOpen = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OpenDoor();
        }
    }

    private void OpenDoor()
    {
        if (isOpen) return;

        isOpen = true;
        animator.SetTrigger("Open");
    }
}