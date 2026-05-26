using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    public AudioSource pickupSound;
    public DoorController doorController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            pickupSound.Play();
            doorController.playerHasKey = true;
            Destroy(gameObject, pickupSound.clip.length);
        }
    }
}