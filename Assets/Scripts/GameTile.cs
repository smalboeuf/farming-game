using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTile
{

    private int x;
    private int y;

    private TileType tileType;
    private bool canBeFarmed;
    private bool canBeHarvested;
    private FarmingTileStatus farmingTileStatus;


    public GameTile(int xPos, int yPos, TileType type, bool canFarm, bool canHarvest, FarmingTileStatus farmTileStatus) {
        x = xPos;
        y = yPos;
        tileType = type;
        canBeFarmed = canFarm;
        canBeHarvested = canHarvest;
        farmingTileStatus = farmTileStatus;
    }

    public TileType GetTileType() {
        return tileType;
    }

    public FarmingTileStatus GetFarmingTileStatus() {
        return farmingTileStatus;
    }

    public bool CanBeHarvested() {
        return canBeHarvested;
    }

    public bool CanBeFarmed() {
        return canBeFarmed;
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