using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTile
{

    private int x;
    private int y;

    private TileType tileType;
    private bool isTilled;
    private bool canBeHarvested;
    private bool isWatered;
    //private FarmingTileStatus farmingTileStatus;
    private Seed plantedSeed;
    private int daysPlanted;



    //Constructor
    public GameTile(int xPos, int yPos, TileType type, bool tileIsTilled, bool canHarvest, bool tileIsWatered, Seed newPlantedSeed, int amountPlanted) {
        x = xPos;
        y = yPos;
        tileType = type;
        isTilled = tileIsTilled;
        canBeHarvested = canHarvest;
        //farmingTileStatus = farmTileStatus;
        plantedSeed = newPlantedSeed;
        daysPlanted = amountPlanted;
    }


    public int GetX() {
        return x;
    }

    public int GetY() {
        return y;
    }

    public bool GetIsWatered() {
        return isWatered;
    }

    public void SetIsWatered(bool newIsWatered)
    {
        isWatered = newIsWatered;
    }

 


    public TileType GetTileType()
    {
        return tileType;
    }

    public void SetTileType(TileType newTiletype) {
        tileType = newTiletype;
    }


    //public FarmingTileStatus GetFarmingTileStatus()
    //{
    //    return farmingTileStatus;
    //}

    //public void SetFarmingTileStatus(FarmingTileStatus newFarmingTileStatus) {
    //    farmingTileStatus = newFarmingTileStatus;
    //}

    public bool GetIsTilled() {
        return isTilled;
    }

    public void SetIsTilled(bool newCanBeTilled) {
        isTilled = newCanBeTilled;
    }

    public bool GetCanBeHarvested() {
        return canBeHarvested;
    }

    public void SetCanBeHarvested(bool newCanBeHarvested) {
        canBeHarvested = newCanBeHarvested;
    }


    public Seed GetPlantedSeed() {
        return plantedSeed; 
    }

    public void SetPlantedSeed(Seed seed) {
        plantedSeed = seed;
    }

    public bool CanPlantSeed() {

        if (isTilled == true && plantedSeed == null) {
            return true;
        }
        return false;
    }

    public int GetDaysPlanted() {
        return daysPlanted;
    }

    public void SetDaysPlanted(int amountOfDays) {
        daysPlanted = amountOfDays;
    }

    public void IncreaseDaysPlanted(int amountOfDays) {
        daysPlanted = daysPlanted + amountOfDays;

        if (daysPlanted >= plantedSeed.GetDaysForFinalPlant()) {
            SetCanBeHarvested(true);
            //SetFarmingTileStatus(FarmingTileStatus.Crops);
        }
    }

    public void ResetPlantedCrop() {

        canBeHarvested = false;
       // farmingTileStatus = FarmingTileStatus.Tilled;
        plantedSeed = null;
        daysPlanted = 0;

        //Change Sprites on the CropsTileManager
        Manager.cropsTileManager.UpdateCropTiles();
    }

}



public enum FarmingTileStatus {
    Basic,
    Tilled,
    TilledAndWatered,
    Planted,
    PlantedAndWatered,
    Crops
}

public enum TileType {
    Grass,
    Stone,
    Snow,
    Wall,
}

public enum CanBeFarmedTiles {
    Grass,
    Snow
}