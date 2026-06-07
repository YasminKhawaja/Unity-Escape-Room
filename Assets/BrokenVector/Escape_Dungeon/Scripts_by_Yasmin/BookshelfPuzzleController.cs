using UnityEngine;

public class BookshelfPuzzleController : MonoBehaviour
{
    [SerializeField] private KeyPickupInteractable keyPickupInteractable;
    [SerializeField] private AudioSource puzzleSolvedAudioSource;
    [SerializeField] private Light feedbackLight;
    [SerializeField] private float solvedLightIntensity = 3.5f;

    private bool isSolved;
    private float defaultLightIntensity;

    public bool IsSolved => isSolved;

    private void Awake()
    {
        if (feedbackLight != null)
        {
            defaultLightIntensity = feedbackLight.intensity;
        }
    }

    public void SolvePuzzle()
    {
        if (isSolved)
        {
            return;
        }

        isSolved = true;
        keyPickupInteractable.UnlockKey();

        if (puzzleSolvedAudioSource != null)
        {
            puzzleSolvedAudioSource.Play();
        }

        if (feedbackLight != null)
        {
            feedbackLight.intensity = solvedLightIntensity;
        }
    }

    public void ResetVisualFeedback()
    {
        if (feedbackLight != null)
        {
            feedbackLight.intensity = defaultLightIntensity;
        }
    }
}
