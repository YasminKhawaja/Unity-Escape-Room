using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class SaveGameManager : MonoBehaviour
{
    public Transform player; // PlayerCapsule hier slepen

    private const string PlayerXKey = "PlayerX";
    private const string PlayerYKey = "PlayerY";
    private const string PlayerZKey = "PlayerZ";

    private void Start()
    {
        LoadGameIfExists();
    }

    // ---------------- SAVE GAME ----------------
    public void SaveGame()
    {
        if (player == null)
        {
            Debug.LogWarning("SaveGameManager: Geen player toegewezen!");
            return;
        }

        Vector3 pos = player.position;

        PlayerPrefs.SetFloat(PlayerXKey, pos.x);
        PlayerPrefs.SetFloat(PlayerYKey, pos.y);
        PlayerPrefs.SetFloat(PlayerZKey, pos.z);

        PlayerPrefs.Save();

        Debug.Log("Game saved: " + pos);
    }

    // ---------------- LOAD GAME ----------------
    public void LoadGameIfExists()
    {
        if (!PlayerPrefs.HasKey(PlayerXKey))
        {
            Debug.Log("SaveGameManager: Geen opgeslagen game gevonden.");
            return;
        }

        float x = PlayerPrefs.GetFloat(PlayerXKey);
        float y = PlayerPrefs.GetFloat(PlayerYKey);
        float z = PlayerPrefs.GetFloat(PlayerZKey);

        Vector3 loadedPos = new Vector3(x, y, z);
        player.position = loadedPos;

        Debug.Log("Game loaded: " + loadedPos);
    }

    // ---------------- RESET SAVE ONLY ----------------
    public void ResetSave()
    {
        PlayerPrefs.DeleteKey(PlayerXKey);
        PlayerPrefs.DeleteKey(PlayerYKey);
        PlayerPrefs.DeleteKey(PlayerZKey);

        PlayerPrefs.Save();

        Debug.Log("Save gereset.");
    }

    // ---------------- RESET GAME (FULL RELOAD) ----------------
    public void ResetGame()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();

        Time.timeScale = 1f;

        var playerInput = FindObjectOfType<PlayerInput>();
        if (playerInput != null)
            playerInput.SwitchCurrentActionMap("Player");

        StartCoroutine(DelayedSceneReload());
    }

    private IEnumerator DelayedSceneReload()
    {
        yield return new WaitForSecondsRealtime(0.1f);

        var uiModule = FindObjectOfType<UnityEngine.InputSystem.UI.InputSystemUIInputModule>();
        if (uiModule != null)
        {
            uiModule.enabled = false;
            yield return null;
            uiModule.enabled = true;
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}