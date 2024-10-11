using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    [SerializeField] private List<Item> Items = new List<Item>();

    [SerializeField] private Transform ItemContent;
    [SerializeField] private GameObject InventoryItem;

   /* void Update()
    {
        ListItems();
    }*/
    public void Awake()
    {
        Instance = this;
    }

    public void Add(Item item)
    {
        Items.Add(item);
    }

    public void Remove(Item item)
    {
        Items.Remove(item);
    }

    public void ListItems()
    {
        foreach(var item in Items)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var itemName = obj.transform.Find("ItemName").GetComponent<Text>();
            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>(); 

            itemName.text = item.itemName;
            itemIcon.sprite = item.icon;
        }
    }
}
