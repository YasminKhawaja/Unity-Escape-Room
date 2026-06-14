using UnityEngine;

public class DiningRoomTrigger : MonoBehaviour
{
    [SerializeField] private DiningTablePuzzleController puzzleController;
    [SerializeField] private string enterMessage = "Zoek de 3 objecten in de kamer.";

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }

        if (puzzleController != null)
        {
            puzzleController.ShowPrompt(enterMessage);
        }
    }
}