using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public abstract class Seed : InventoryItem
{

    [SerializeField] private int m_daysToGrow;
    [SerializeField] private int m_daysForMidPlant;
    [SerializeField] private int m_daysForFinalPlant;

    [SerializeField] private Tile m_plantedTile;
    [SerializeField] private Tile m_midPlantedTile;
    [SerializeField] private Tile m_finalPlantedTile;

    [SerializeField] private InventoryItem crop;

    public int daysToGrow => m_daysToGrow;
    public int daysForMidPlant => m_daysForMidPlant;
    public int daysForFinalPlant => m_daysForFinalPlant;

    public Tile plantedTile => m_plantedTile;
    public Tile midPlantedTile => m_midPlantedTile;
    public Tile finalPlantedTile => m_finalPlantedTile;


    public void UseSeed(Seed seed, int xPos, int yPos)
    {
        //Check to see if can plant
        if (Manager.gameTileManager.gameTileMap[xPos, yPos].CanPlantSeed())
        {
            //Plant it
            Manager.cropsTileManager.PlantSeed(seed, xPos, yPos);
            //if successful, remove 1 seed from your inventory
            Manager.inventoryManager.RemoveItemAtHotbarIndex(Manager.hotbarManager.selectedSlot, seed);

            //Update UI
            Manager.hotbarManager.UpdateHotbarSlots();
        }
    }

    public InventoryItem GetCropForHarvesting()
    {
        return crop;
    }
}
