using UnityEngine;

[CreateAssetMenu (fileName = "New Item",menuName = "Item/Create New Item")]
public class Item : ScriptableObject
{
    [SerializeField] private int id;
    [SerializeField] private int value;
    public string itemName;
    
    public Sprite icon;
}
