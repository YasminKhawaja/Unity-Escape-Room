// using UnityEngine;

// public class KeyPickup : MonoBehaviour
// {
//     public AudioSource pickupSound;
//     public DoorController doorController;

//     private void OnTriggerEnter(Collider other)
//     {
//         if (other.CompareTag("Player"))
//         {
//             pickupSound.Play();
//             doorController.playerHasKey = true;
//             Destroy(gameObject, pickupSound.clip.length);
//         }
//     }
// }


using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    public string keyID; // bv. "FireKey", "BasementKey"
    public AudioSource pickupSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var inv = other.GetComponent<PlayerInventory>();
            inv.AddKey(keyID);

            pickupSound.Play();
            Destroy(gameObject, pickupSound.clip.length);
        }
    }
}
