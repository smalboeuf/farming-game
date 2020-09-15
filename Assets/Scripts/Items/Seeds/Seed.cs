using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public abstract class Seed : InventoryItem
{



    [SerializeField] private int daysToGrow;
    [SerializeField] private int daysForMidPlant;
    [SerializeField] private int daysForFinalPlant;

    [SerializeField] private Tile plantedTile;
    [SerializeField] private Tile midPlantedTile;
    [SerializeField] private Tile finalPlantedTile;

    [SerializeField] private InventoryItem crop;


    public void UseSeed(Seed seed, int xPos, int yPos) {
        
        //Check to see if can plant
        if (Manager.gameTileManager.gameTileMap[xPos, yPos].CanPlantSeed()) {
            //Plant it
            Manager.cropsTileManager.PlantSeed(seed, xPos, yPos);
            //if successful, remove 1 seed from your inventory
            Manager.inventoryManager.RemoveItemAtHotbarIndex(Manager.hotbarManager.selectedSlot, seed);

            //Update UI
            Manager.hotbarManager.UpdateHotbarSlots();
           
        }
    }



    public Tile GetPlantedTile() {
        return plantedTile;
    }

    public Tile GetMidPlantedTile() {
        return midPlantedTile;
    }

    public Tile GetFinalPlantedTile () {
        return finalPlantedTile;
    } 

    public int GetDaysToGrow() {
        return daysToGrow;
    }

    public int GetDaysForMidPlant() {
        return daysForMidPlant;
    }

    public int GetDaysForFinalPlant() {
        return daysForFinalPlant;
    }

    public InventoryItem GetCropForHarvesting() {
        return crop;
    }
}
