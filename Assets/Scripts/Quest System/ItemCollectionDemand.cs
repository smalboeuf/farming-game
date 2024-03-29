using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item Collection Demand", menuName = "Quest System/Demands/Item Collection Demand")]
public class ItemCollectionDemand : ScriptableObject
{
    public InventoryItem item;
    public bool collected = false;
}
