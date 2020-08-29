﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTile
{

    private int x;
    private int y;

    private TileType tileType;
    private bool canBeTilled;
    private bool canBeHarvested;
    private FarmingTileStatus farmingTileStatus;


    public GameTile(int xPos, int yPos, TileType type, bool canTill, bool canHarvest, FarmingTileStatus farmTileStatus) {
        x = xPos;
        y = yPos;
        tileType = type;
        canBeTilled = canTill;
        canBeHarvested = canHarvest;
        farmingTileStatus = farmTileStatus;
    }

    public int GetX() {
        return x;
    }

    public int GetY() {
        return y;
    }


    public TileType GetTileType()
    {
        return tileType;
    }

    public void SetTileType(TileType newTiletype) {
        tileType = newTiletype;
    }


    public FarmingTileStatus GetFarmingTileStatus()
    {
        return farmingTileStatus;
    }

    public void SetFarmingTileStatus(FarmingTileStatus newFarmingTileStatus) {
        farmingTileStatus = newFarmingTileStatus;
    }

    public bool GetCanBeTilled() {
        return canBeTilled;
    }

    public void SetCanBeTilled(bool newCanBeTilled) {
        canBeTilled = newCanBeTilled;
    }

    public bool GetCanBeHarvested() {
        return canBeHarvested;
    }

    public void SetCanBeHarvested(bool newCanBeHarvested) {
        canBeHarvested = newCanBeHarvested;
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