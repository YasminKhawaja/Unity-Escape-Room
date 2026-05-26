using UnityEngine;

public class RoomPuzzleState : MonoBehaviour
{
    private bool hasReadRiddle;
    private bool isChestUnlocked;
    private bool isChestOpen;
    private bool isKeyCollected;

    public bool HasReadRiddle => hasReadRiddle;
    public bool IsChestUnlocked => isChestUnlocked;
    public bool IsChestOpen => isChestOpen;
    public bool IsKeyCollected => isKeyCollected;

    public void SetRiddleRead()
    {
        hasReadRiddle = true;
    }

    public void UnlockChest()
    {
        isChestUnlocked = true;
    }

    public void OpenChest()
    {
        isChestOpen = true;
    }

    public void CollectKey()
    {
        isKeyCollected = true;
    }
}