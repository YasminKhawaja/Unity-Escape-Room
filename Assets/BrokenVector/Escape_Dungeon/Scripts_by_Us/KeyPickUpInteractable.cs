using UnityEngine;

public class KeyPickUpInteractable : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private RoomPuzzleState roomPuzzleState;
    [SerializeField] private AudioSource pickupAudioSource;

    private bool canBeCollected;

    public void UnlockKey()
    {
        canBeCollected = true;
        gameObject.SetActive(true);
    }

    public void Interact()
    {
        if (!canBeCollected)
        {
            return;
        }

        if (pickupAudioSource != null)
        {
            pickupAudioSource.Play();
        }

        roomPuzzleState.CollectKey();
        gameObject.SetActive(false);
    }
}
