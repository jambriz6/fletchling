using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    [SerializeField] private Item Item;

    public void Pickup()
    {
        InventoryManager.Instance.Add(Item);
        //Destroy(gameObject);
        gameObject.SetActive(false);
    }

    /*private void OnMouseDown()
    {
        Pickup();
    }*/
}
