using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdManager : MonoBehaviour
{
    public Image mainAdImage;         // Image for the main ad
    public Image descriptionImage;   // Image for the ad description (text image)
    public Button[] thumbnailButtons; // Buttons for selecting ads
    public float cycleInterval = 5f;  // Time to cycle through ads
    public AdSet[] adSets;            // Array of available ad sets
    public AdSet defaultAdSet;        // Default ad set when others expire

    private AdSet currentAdSet;       // Currently active ad set
    private int currentAdIndex = 0;   // Index of the currently displayed ad

    void Start()
    {
        // Set the default ad set if available
        if (defaultAdSet != null)
        {
            currentAdSet = defaultAdSet;
            ApplyAdSet(currentAdSet);
        }
        StartCoroutine(CycleAds());
    }

    void Update()
    {
        // Implement your date-based ad set switch logic here
    }

    // Apply the selected ad set to the ad board
    void ApplyAdSet(AdSet adSet)
    {
        currentAdSet = adSet;
        for (int i = 0; i < thumbnailButtons.Length; i++)
        {
            if (i < adSet.adBlocks.Length)
            {
                thumbnailButtons[i].GetComponent<Image>().sprite = adSet.adBlocks[i].thumbnailSprite;
                thumbnailButtons[i].onClick.RemoveAllListeners();
                int index = i;  // Capture the current index in a local variable
                thumbnailButtons[i].onClick.AddListener(() => SetActiveAd(index));
            }
            else
            {
                thumbnailButtons[i].GetComponent<Image>().sprite = null;
                thumbnailButtons[i].interactable = false;
            }
        }
        UpdateMainAdImage();
        UpdateDescriptionImage();
    }

    // Coroutine to cycle through ads at regular intervals
    IEnumerator CycleAds()
    {
        while (true)
        {
            yield return new WaitForSeconds(cycleInterval);
            currentAdIndex = (currentAdIndex + 1) % currentAdSet.adBlocks.Length;
            UpdateMainAdImage();
            UpdateDescriptionImage();
        }
    }

    // Update the main ad image based on the current ad
    void UpdateMainAdImage()
    {
        if (currentAdSet != null && currentAdSet.adBlocks.Length > 0)
        {
            mainAdImage.sprite = currentAdSet.adBlocks[currentAdIndex].fullSizeAd;
        }
    }

    // Update the description image based on the current ad
    void UpdateDescriptionImage()
    {
        if (currentAdSet != null && currentAdSet.adBlocks.Length > 0)
        {
            descriptionImage.sprite = currentAdSet.adBlocks[currentAdIndex].infoSprite;
        }
    }

    // Set the active ad and update the UI accordingly
    void SetActiveAd(int index)
    {
        if (index >= 0 && index < currentAdSet.adBlocks.Length)
        {
            currentAdIndex = index;
            UpdateMainAdImage();
            UpdateDescriptionImage();
        }
    }
}

