using UnityEngine;

public class VaseInteractable : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject keyObject;
    [SerializeField] private AudioSource tipOverAudioSource;

    [Header("Settings")]
    [SerializeField] private string tipOverTriggerName = "TipOver";

    private bool hasTippedOver;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Enter: " + other.gameObject.name + " | Tag: " + other.tag);

        if (hasTippedOver || !other.CompareTag("Player"))
        {
            return;
        }

        TipOver();
    }

    private void TipOver()
    {
        hasTippedOver = true;
        Debug.Log("Vaas valt om!");

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