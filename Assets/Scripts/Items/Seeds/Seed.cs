using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Seed : InventoryItem
{
    [SerializeField] private int daysToGrow;
    [SerializeField] private Sprite plantedSprite;
    public abstract void UseSeed(Seed seed, int xPos, int yPos);

    
}
