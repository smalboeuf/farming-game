using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Consumable : InventoryItem
{


    public virtual void Food(int hotbarIndex, InventoryItem item) { }
    public virtual void Seeds(int hotbarIndex, InventoryItem item) { }



    public void UseConsumable(int hotbarIndex, InventoryItem item) {

        switch (item.GetItemType())
        {
            case ItemType.Food:
                Food(hotbarIndex ,item);
                break;

            case ItemType.Seeds:
                Seeds(hotbarIndex, item);
                break;

            default:
                Debug.Log("ItemType not found");
                break;

        }
    }

   
}
