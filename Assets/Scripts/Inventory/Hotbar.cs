using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Hotbar", menuName = "Inventory/Player Hotbar")]
public class Hotbar : ScriptableObject
{

    public InventoryItem[] myHotbar = new InventoryItem[8];

}
