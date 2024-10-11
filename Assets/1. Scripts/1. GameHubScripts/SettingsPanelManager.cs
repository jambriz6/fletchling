using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using LootLocker.Requests;

public class SettingsPanelManager : MonoBehaviour
{
    // Reference to the panel that will show logout and other options
    [SerializeField] private GameObject SettingsPanel; 
    [SerializeField] private Button SettingsButton;
    [SerializeField] private Button LogoutButton;

    private void Start()
    {
        // Hide the panel at the start
        SettingsPanel.SetActive(false);

        // Add listener to the settings button to show or hide the panel
        SettingsButton.onClick.AddListener(ToggleSettingsPanel);
        LogoutButton.onClick.AddListener(OnLogoutButtonClicked);
    }

    private void OnLogoutButtonClicked()
    {
        LootLockerSDKManager.EndSession((response) =>
        {
            if (response.success) {
                Debug.Log("Successfully logged out and session ended.");
                SceneManager.LoadScene("0.StartScene - Login");
            } else {
                Debug.LogError("ERROR WHILE TRYING TO LOG OUT AND END SESSION! NOTIFY ADMIN!");
            }
        });
    }

    // Method to toggle the settings panel visibility
    private void ToggleSettingsPanel()
    {
        // Toggle the active state of the settings panel
        SettingsPanel.SetActive(!SettingsPanel.activeSelf);
    }

}
