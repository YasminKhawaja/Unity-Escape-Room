using System.Collections;
using UnityEngine;

public class HiddenCluePot : InteractableBase
{
    [Header("Movement")]
    [SerializeField] private Transform potTransform;
    [SerializeField] private Vector3 moveOffset = new Vector3(0.5f, 0f, 0f);
    [SerializeField] private float moveSpeed = 1.5f;

    [Header("Hidden Key")]
    [SerializeField] private GameObject hiddenKey;
    [SerializeField] private KeyPickUpInteractable keyPickUpInteractable;

    [Header("Audio")]
    [SerializeField] private AudioSource moveAudioSource;

    private bool isActivated;
    private Vector3 targetPosition;

    private void Awake()
    {
        if (potTransform == null)
        {
            potTransform = transform;
        }

        targetPosition = potTransform.position + moveOffset;

        if (hiddenKey != null)
        {
            hiddenKey.SetActive(false);
        }
    }

    public override void Interact()
    {
        if (isActivated)
        {
            return;
        }

        isActivated = true;

        if (moveAudioSource != null)
        {
            moveAudioSource.Play();
        }

        StartCoroutine(MovePot());
    }

    private IEnumerator MovePot()
    {
        while (Vector3.Distance(potTransform.position, targetPosition) > 0.01f)
        {
            potTransform.position = Vector3.MoveTowards(
                potTransform.position,
                targetPosition,
                moveSpeed * Time.deltaTime
            );

            yield return null;
        }

        potTransform.position = targetPosition;

        if (hiddenKey != null)
        {
            hiddenKey.SetActive(true);
        }

        if (keyPickUpInteractable != null)
        {
            keyPickUpInteractable.UnlockKey();
        }
    }
}
