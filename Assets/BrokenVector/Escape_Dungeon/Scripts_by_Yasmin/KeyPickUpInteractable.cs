using UnityEngine;

public class KeyPickupInteractable : InteractableBase
{
    [SerializeField] private string keyID = "Key";
    [SerializeField] private AudioClip pickupSound;

    public override void Interact()
    {
        Debug.Log("Sleutel interact gestart: " + keyID);

        InventorySystem.AddKey(keyID);

        if (pickupSound != null)
        {
            AudioSource.PlayClipAtPoint(pickupSound, transform.position);
        }

        gameObject.SetActive(false);
    }
}