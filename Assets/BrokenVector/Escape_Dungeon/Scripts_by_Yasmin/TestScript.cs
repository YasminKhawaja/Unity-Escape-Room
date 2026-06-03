using UnityEngine;

public class TestScript : MonoBehaviour
{
    private Animator mAnimator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mAnimator = GetComponent<Animator>();
        Debug.Log("TEST WERKT op: Treasure_Chest_Base_02");
    }

    // Update is called once per frame
    void Update()
    {
        if (mAnimator != null)
        {
            if (Input.GetKeyDown(KeyCode.O))
            {
                mAnimator.SetTrigger("Open");
            }
        }
    }
}
