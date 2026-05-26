using UnityEngine;

public class FireplaceAudioTrigger : MonoBehaviour
{
    public AudioSource fireplaceAudio;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!fireplaceAudio.isPlaying)
                fireplaceAudio.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            fireplaceAudio.Stop();
        }
    }
}