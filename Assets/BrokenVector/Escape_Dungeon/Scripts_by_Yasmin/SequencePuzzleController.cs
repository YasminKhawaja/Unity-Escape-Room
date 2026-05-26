using UnityEngine;

public class SequencePuzzleController : MonoBehaviour
{
    [SerializeField] private PuzzleClickableObject[] correctSequence;
    [SerializeField] private TreasureChestController treasureChestController;

    private int currentIndex;
    private bool isSolved;
    private bool isActive;

    public void ActivatePuzzle()
    {
        isActive = true;
    }

    public void RegisterObjectClick(PuzzleClickableObject clickedObject)
    {
        if (!isActive)
        {
            return;
        }

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