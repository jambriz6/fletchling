using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour
{
    public GameObject HomePanel; // Array to hold all tab GameObjects
    public Button HomeButton; // Array to hold all tab buttons

    /*
    public bool resetOnDisable; // Checkbox to determine if tabs should reset on disable
    private int currentTabIndex = 0; // Index of the currently active tab
    */

    void Start()
    {
        ShowHomePanel();





        /*
        if (tabs.Length != tabButtons.Length) {
            Debug.LogError("Tabs and tabButtons arrays must be the same length.");
            return;
        }
        // Tab Initalization
        for (int i = 0; i < tabs.Length; i++) {
            tabs[i].SetActive(i == currentTabIndex);
        }
        // Add listeners to tab buttons
        for (int i = 0; i < tabButtons.Length; i++) {
            int index = i;
            tabButtons[i].onClick.AddListener(() => SwitchTab(index));
        }
        // Initialize button interactability
        UpdateButtonInteractability();
        */
    }

    void ShowHomePanel()
    {
        HomePanel.SetActive(true);

    }


    /*
    public void SwitchTab(int tabIndex)
    {
        if (tabIndex == currentTabIndex) {
            return; // Do nothing if trying to switch to the same tab
        }

        // Disable the current tab
        tabs[currentTabIndex].SetActive(false);

        // Enable the new tab
        tabs[tabIndex].SetActive(true);

        // Update the button interactability
        currentTabIndex = tabIndex;
        UpdateButtonInteractability();
    }

    private void UpdateButtonInteractability()
    {
        for (int i = 0; i < tabButtons.Length; i++) {
            tabButtons[i].interactable = (i != currentTabIndex);
        }
    }

    // Optional: Reset tabs when the menu is disabled, if specified in the editor
    private void OnDisable()
    {
        if (resetOnDisable) {
            ResetTabs();
        }
    }

    private void ResetTabs()
    {
        // Ensure all tabs are deactivated
        for (int i = 0; i < tabs.Length; i++) {
            tabs[i].SetActive(false);
        }
        // Activate the first tab
        if (tabs.Length > 0) {
            tabs[0].SetActive(true);
        }
        // Update currentTabIndex
        currentTabIndex = 0;
        // Reset button interactability
        UpdateButtonInteractability();
    }
    */
}
