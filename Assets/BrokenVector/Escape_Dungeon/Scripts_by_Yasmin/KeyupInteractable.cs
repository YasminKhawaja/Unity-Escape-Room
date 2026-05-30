using UnityEngine;

public class KeyPickupInteractable : InteractableBase
{
    [SerializeField] private AudioSource pickupAudioSource;
    [SerializeField] private GameObject lockedVisualEffect;
    [SerializeField] private GameObject unlockedVisualEffect;

    private bool canBeCollected;
    private bool isCollected;

    public bool IsCollected => isCollected;
    public bool CanBeCollected => canBeCollected;

    public void UnlockKey()
    {
        canBeCollected = true;

        if (lockedVisualEffect != null)
        {
            lockedVisualEffect.SetActive(false);
        }

        if (unlockedVisualEffect != null)
        {
            unlockedVisualEffect.SetActive(true);
        }
    }

    public override void Interact()
    {
        if (!canBeCollected || isCollected)
        {
            return;
        }

        isCollected = true;

        if (pickupAudioSource != null)
        {
            pickupAudioSource.Play();
        }

        gameObject.SetActive(false);
    }
}
