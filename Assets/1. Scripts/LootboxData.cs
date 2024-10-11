using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewLootboxData", menuName = "Lootbox Data", order = 52)]
public class LootboxData : ScriptableObject
{
    // Loot locker ID 
    [Header("Loot Locker ID")]
    public string lootLockerID;

    // in game ID 
    [Header("InGame ID")]
    public string lootboxID;

    // Basic lootbox information
    [Header("Lootbox Information")]

    public string lootboxName;
    public string collectionName;
    public string setName;
    public string volumeNumber;

    // Visual elements
    [Header("Visuals")]
    public Sprite lootboxSprite2D; // Sprite for the lootbox image in 2D UI
    public Sprite descriptionSprite;

    // Physical lootbox properties
    [Header("Physical Lootbox Properties")]
    public Sprite lootboxMaterial; // Material to apply to the lootbox mesh
    public GameObject lootbox3DModel; // 3D Model of the lootbox

    // Animation for lootbox (if applicable)
    [Header("Animations")]
    public AnimationClip lootboxAnimation;


    // Pricing and value
    [Header("Pricing")]
    public PricingInfo pricing;


    // Category tags for search and filtering
    [Header("Category Tags")]
    public List<string> categoryTags;

    // Define the PricingInfo class for currencies
    [System.Serializable]
    public class PricingInfo
    {
        public int coins;
        public int tickets;
        public int scraps;
    }
}
