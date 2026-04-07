using UnityEngine;
using StarterAssets;
using UnityEngine.InputSystem;

public class SettingsMenuController : MonoBehaviour
{
    [Header("References")]
    public GameObject settingsPanel;
    public FirstPersonController playerController;
    public PlayerInput playerInput;

    [Header("Player Reset")]
    public Transform player;               // <-- speler referentie
    public Transform playerSpawnPoint;     // <-- spawnpunt referentie

    private bool isOpen = false;

    // =========================
    // RESET BIJ START
    // =========================
    private void Start()
    {
        settingsPanel.SetActive(false);
        isOpen = false;

        Time.timeScale = 1f;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        playerInput.SwitchCurrentActionMap("Player");
        playerController.IsInMenu = false;

        Debug.Log("SettingsMenuController: reset OK");
    }

    // =========================
    // ESC → WORDT AANGEROEPEN VIA SEND MESSAGES
    // =========================
    public void OnCancel(InputValue value)
    {
        if (!value.isPressed)
            return;

        ToggleMenu();
    }

    // =========================
    // EXIT BUTTON
    // =========================
    public void ExitSettings()
    {
        if (isOpen)
        {
            ToggleMenu();
        }
    }

    // =========================
    // RESET KNOP (WORDT AANGEROEPEN DOOR UI BUTTON)
    // =========================
    public void ResetGame()
    {
        // Zet speler terug naar spawn
        if (player != null && playerSpawnPoint != null)
        {
            player.position = playerSpawnPoint.position;
            player.rotation = playerSpawnPoint.rotation;
        }

        Debug.Log("RESET GAME: Player teruggezet naar spawn.");
    }

    // =========================
    // CENTRALE MENU LOGICA
    // =========================
    private void ToggleMenu()
    {
        isOpen = !isOpen;
        settingsPanel.SetActive(isOpen);

        if (isOpen)
        {
            FindObjectOfType<VolumeController>()?.Init();

            // MENU OPEN
            Time.timeScale = 0f;

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            playerInput.SwitchCurrentActionMap("UI");
            playerController.IsInMenu = true;
        }
        else
        {
            // MENU DICHT
            Time.timeScale = 1f;

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            playerInput.SwitchCurrentActionMap("Player");
            playerController.IsInMenu = false;
        }

        Debug.Log("MENU OPEN = " + isOpen);
    }
}