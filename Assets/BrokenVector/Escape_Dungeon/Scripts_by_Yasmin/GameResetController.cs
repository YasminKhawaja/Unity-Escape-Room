using UnityEngine;
using UnityEngine.SceneManagement;

public class GameResetController : MonoBehaviour
{
    public void ResetGame()
    {
        // Zorg dat tijd normaal loopt
        Time.timeScale = 1f;

        // Cursor resetten (veilig)
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Huidige scene opnieuw laden
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);

        PlayerPrefs.DeleteKey("PlayerX");
PlayerPrefs.DeleteKey("PlayerY");
PlayerPrefs.DeleteKey("PlayerZ");
    }
}
