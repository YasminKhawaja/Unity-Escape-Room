using UnityEngine;

public class VaseInteractable : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Header("References")]
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject keyObject;
    [SerializeField] private AudioSource tipOverAudioSource;

    [Header("Settings")]
    [SerializeField] private string tipOverTriggerName = "TipOver";
    [SerializeField] private KeyCode interactKey = KeyCode.V;

    private bool playerInRange;
    private bool hasTippedOver;

    private void Update()
    {
        if (playerInRange && !hasTippedOver && Input.GetKeyDown(interactKey))
        {
            TipOver();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    private void TipOver()
    {
        hasTippedOver = true;

        if (animator != null)
        {
            animator.SetTrigger(tipOverTriggerName);
        }

        if (tipOverAudioSource != null)
        {
            tipOverAudioSource.Play();
        }

        if (keyObject != null)
        {
            keyObject.SetActive(true);
        }
    }
}
