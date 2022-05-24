using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    public Inventory inventory;
    
    // Add items to send this metod in inventory.
    public void DropItems(Item[] items)
    {
        for (int i = 0 ; i < items.Length ; i++)
        {
            inventory.AddItem(items[i]);
        }
    }
}
