using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Carrot", menuName = "Inventory/Consumables/Food/Carrot")]
public class Carrot : Consumable
{

    [SerializeField] private int healing;

    public override void Food(int hotbarIndex, InventoryItem item)
    {
        //Heal the health
        Manager.character.Heal(healing);
        //Remove a carrot from your inventory
        Manager.inventoryManager.RemoveItemAtHotbarIndex(hotbarIndex ,item);
        Manager.hotbarManager.UpdateHotbarSlots();
    }

}
