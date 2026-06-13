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
        Debug.Log("TRIGGER geraakt door: " + other.name + " | tag: " + other.tag, this);

        if (hasTippedOver || !other.CompareTag("Player"))
        {
            return;
        }
        //  if (!other.CompareTag("Player"))
        //     return;
        Debug.Log("PLAYER in trigger!", this);
        TipOver();
    }

    private void TipOver()
    {
        hasTippedOver = true;
        Debug.Log("Vaas schuift naar voor!");

        if (animator != null)
        {
            Debug.Log("Trigger gezet op animator: " + tipOverTriggerName, this);
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
        else
        {
            Debug.Log("Animator referece ontbreekt");
        }
    }
}