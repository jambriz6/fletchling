using UnityEngine;
using LootLocker.Requests;

public class LootBox : MonoBehaviour
{
    public GameObject[] cardPrefabs; // Array of card prefabs
    public int packCount = 0; // Number of packs in inventory
    public Nav_UI navUI; // Reference to the Nav_UI component
    public Transform cardSpawnPoint; // Reference to the Transform where cards will be instantiated

    private void Start()
    {
        // Assuming the player is logged in through the LoginManager and the session is started
        // Initialize the UI with the current pack count
        navUI.UpdatePackCount(packCount);
    }

    public void OpenPack()
    {
        // Check if there are packs to open
        if (packCount > 0)
        {
            // Decrease the pack count
            packCount--;

            // Update the pack count in Loot Locker
            UpdatePackCountInLootLocker(packCount);

            // Instantiate 3 random cards at the specified spawn point
            GameObject[] obtainedCards = new GameObject[3];
            for (int i = 0; i < 3; i++)
            {
                int randomIndex = Random.Range(0, cardPrefabs.Length);
                GameObject card = Instantiate(cardPrefabs[randomIndex], cardSpawnPoint.position, Quaternion.identity, cardSpawnPoint);
                obtainedCards[i] = card;
            }

            // Update the pack count in your game inventory UI
            navUI.UpdatePackCount(packCount);

            // Save the obtained cards to Loot Locker
            SaveObtainedCardsToLootLocker(obtainedCards);
        }
        else
        {
            Debug.Log("No packs available to open.");
        }
    }

    private void UpdatePackCountInLootLocker(int count)
    {
        LootLockerSDKManager.UpdateOrCreateKeyValue("packCount", count.ToString(), (response) =>
        {
            if (response.success)
            {
                Debug.Log("Pack count updated in Loot Locker.");
            }
            else
            {
                Debug.Log("Failed to update pack count in Loot Locker.");
                Debug.Log("Error: " + response.errorData);
            }
        });
    }

    private void SaveObtainedCardsToLootLocker(GameObject[] obtainedCards)
    {
        string cardData = "";

        foreach (GameObject card in obtainedCards)
        {
            CardController cardController = card.GetComponent<CardController>();
            if (cardController != null)
            {
                Item item = cardController.item;
                cardData += item.itemName + ",";
            }
        }

        // Remove the trailing comma
        if (cardData.Length > 0)
        {
            cardData = cardData.Substring(0, cardData.Length - 1);
        }

        LootLockerSDKManager.UpdateOrCreateKeyValue("obtainedCards", cardData, (response) =>
        {
            if (response.success)
            {
                Debug.Log("Obtained cards saved to Loot Locker.");
            }
            else
            {
                Debug.Log("Failed to save obtained cards to Loot Locker.");
                Debug.Log("Error: " + response.errorData);
            }
        });
    }
}
