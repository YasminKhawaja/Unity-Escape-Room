using System.Collections;
using UnityEngine;

public class HiddenCluePot : InteractableBase
{
    [Header("References")]
    [SerializeField] private Transform potRoot;
    [SerializeField] private GameObject hiddenKey;
    [SerializeField] private KeyPickUpInteractable keyPickUpInteractable;
    [SerializeField] private AudioSource moveAudioSource;

    [Header("Movement")]
    [SerializeField] private Vector3 localMoveOffset = new Vector3(0.5f, 0f, 0f);
    [SerializeField] private float moveSpeed = 1.5f;

    private bool isActivated;
    private Vector3 startLocalPosition;
    private Vector3 targetLocalPosition;

    private void Awake()
    {
        if (potRoot == null)
        {
            potRoot = transform;
        }

        startLocalPosition = potRoot.localPosition;
        targetLocalPosition = startLocalPosition + localMoveOffset;

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
        while (Vector3.Distance(potRoot.localPosition, targetLocalPosition) > 0.01f)
        {
            potRoot.localPosition = Vector3.MoveTowards(
                potRoot.localPosition,
                targetLocalPosition,
                moveSpeed * Time.deltaTime
            );

            yield return null;
        }

        potRoot.localPosition = targetLocalPosition;

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