using UnityEngine;

public class SequencePuzzleController : MonoBehaviour
{
    [SerializeField] private PuzzleClickableObject[] correctSequence;
    [SerializeField] private TreasureChestController treasureChestController;

    private int currentIndex;
    private bool isSolved;

    public void RegisterObjectClick(PuzzleClickableObject clickedObject)
    {
        if (isSolved)
        {
            return;
        }

        if (clickedObject == correctSequence[currentIndex])
        {
            currentIndex++;

            if (currentIndex >= correctSequence.Length)
            {
                SolvePuzzle();
            }
        }
        else
        {
            ResetPuzzle();
        }
    }

    private void SolvePuzzle()
    {
        isSolved = true;
        treasureChestController.OpenChest();
    }

    private void ResetPuzzle()
    {
        currentIndex = 0;
    }
}
