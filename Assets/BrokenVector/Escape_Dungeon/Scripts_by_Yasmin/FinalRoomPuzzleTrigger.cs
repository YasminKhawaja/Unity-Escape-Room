using UnityEngine;

public class FinalRoomPuzzleTrigger : MonoBehaviour
{
    [SerializeField] private SequencePuzzleController sequencePuzzleController;
    [SerializeField] private string playerTag = "Player";

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(playerTag))
        {
            return;
        }

        sequencePuzzleController.ActivatePuzzle();
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag(playerTag))
        {
            return;
        }

        sequencePuzzleController.DeactivatePuzzle();
    }
}