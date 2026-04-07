using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public AudioSource footstepAudio;
    public float stepInterval = 0.5f; 
    private float stepTimer;

    void Update()
    {
        // Werkt op AZERTY, QZSD, WASD, controller, alles
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        bool isMoving = Mathf.Abs(moveX) > 0.1f || Mathf.Abs(moveZ) > 0.1f;

        if (isMoving)
        {
            stepTimer -= Time.deltaTime;

            if (stepTimer <= 0f)
            {
                footstepAudio.Play();
                stepTimer = stepInterval;
            }
        }
        else
        {
            stepTimer = 0f;
        }
    }
}