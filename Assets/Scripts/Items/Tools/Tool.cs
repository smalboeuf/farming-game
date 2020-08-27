using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tool : InventoryItem
{
    public abstract void UseTool(int xPos, int yPos);
}
