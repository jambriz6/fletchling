using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCardData", menuName = "Card Data", order = 51)]
public class CardData : ScriptableObject
{
    // Card ID
    [Header("Card ID")]
    public string cardID; // Unique identifier for the card

    // Basic card information
    [Header("Card Information")]
    public string cardName; // Name of the card
    public Sprite descriptionSprite; // Sprite for the card description
    public string cardBrand; // brand of card

    // Visual elements
    [Header("Visuals")]
    public Sprite cardSprite; // Sprite for the card image in 2D UI

    // Physical card properties
    [Header("Physical Card Properties")]
    public Sprite cardMaterial; // Material to apply to the card (if applicable)
    public GameObject card3DModel; // 3D Model of the card (if applicable)

    // Animation for the card (if applicable)
    [Header("Animations")]
    public AnimationClip cardAnimation;

    // Pricing and value
    [Header("Pricing")]
    public PricingInfo pricing; // Pricing information for acquiring the card

    // Category tags for search and filtering
    [Header("Category Tags")]
    public List<string> categoryTags; // Tags to categorize and filter the card

    // Define the PricingInfo class for currencies
    [System.Serializable]
    public class PricingInfo
    {
        public int coins;
        public int tokens;
        public int scraps;
    }
}
