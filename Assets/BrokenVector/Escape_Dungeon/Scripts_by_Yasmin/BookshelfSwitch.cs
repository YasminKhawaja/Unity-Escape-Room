// using UnityEngine;

// public class BookshelfSwitch : InteractableBase
// {
//     [SerializeField] private BookshelfPuzzleController bookshelfPuzzleController;
//     [SerializeField] private AudioSource clickAudioSource;
//     [SerializeField] private GameObject switchVisual;

//     private bool isActivated;

//     public override void Interact()
//     {
//         if (isActivated)
//         {
//             return;
//         }

//         isActivated = true;

//         if (clickAudioSource != null)
//         {
//             clickAudioSource.Play();
//         }

//         if (switchVisual != null)
//         {
//             switchVisual.SetActive(false);
//         }

//         bookshelfPuzzleController.SolvePuzzle();
//     }
// }