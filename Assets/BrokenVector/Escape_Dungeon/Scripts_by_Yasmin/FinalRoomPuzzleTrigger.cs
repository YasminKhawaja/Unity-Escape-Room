using UnityEngine;

public class FinalRoomPuzzleTrigger : MonoBehaviour
{
    [SerializeField] private SequencePuzzleController sequencePuzzleController;
    [SerializeField] private string playerTag = "Player";
    [SerializeField] private bool disableAfterActivation = true;

    private bool hasActivated;

    private void OnTriggerEnter(Collider other)
    {
        if (hasActivated)
        {
            return;
        }

        if (!other.CompareTag(playerTag))
        {
            return;
        }

        hasActivated = true;
        sequencePuzzleController.ActivatePuzzle();

        if (disableAfterActivation)
        {
            gameObject.SetActive(false);
        }
    }
}
