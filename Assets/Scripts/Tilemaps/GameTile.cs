using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTile
{
    private int x;
    private int y;

    private TileType m_tileType;
    private bool m_isTilled;
    private bool m_canBeHarvested;
    private bool m_isWatered;
    //private FarmingTileStatus farmingTileStatus;
    private Seed m_plantedSeed;
    private int m_daysPlanted;

    public TileType tileType => m_tileType;
    public bool isTilled => m_isTilled;
    public bool canBeHarvested => m_canBeHarvested;
    public bool isWatered => m_isWatered;
    public Seed plantedSeed => m_plantedSeed;
    public int daysPlanted => m_daysPlanted;

    //Constructor
    public GameTile(int xPos, int yPos, TileType type, bool tileIsTilled, bool canHarvest, bool tileIsWatered, Seed newPlantedSeed, int amountPlanted)
    {
        x = xPos;
        y = yPos;
        m_tileType = type;
        m_isTilled = tileIsTilled;
        m_canBeHarvested = canHarvest;
        //farmingTileStatus = farmTileStatus;
        m_plantedSeed = newPlantedSeed;
        m_daysPlanted = amountPlanted;
    }

    public int GetX()
    {
        return x;
    }

    public int GetY()
    {
        return y;
    }

    public void SetIsWatered(bool newIsWatered)
    {
        m_isWatered = newIsWatered;
    }

    public void SetTileType(TileType newTiletype)
    {
        m_tileType = newTiletype;
    }

    public void SetIsTilled(bool newCanBeTilled)
    {
        m_isTilled = newCanBeTilled;
    }

    public void SetCanBeHarvested(bool newCanBeHarvested)
    {
        m_canBeHarvested = newCanBeHarvested;
    }

    public void SetPlantedSeed(Seed seed)
    {
        m_plantedSeed = seed;
    }

    public bool CanPlantSeed()
    {
        if (m_isTilled && m_plantedSeed == null)
        {
            return true;
        }
        return false;
    }

    public void SetDaysPlanted(int amountOfDays)
    {
        m_daysPlanted = amountOfDays;
    }

    public void IncreaseDaysPlanted(int amountOfDays)
    {
        m_daysPlanted = m_daysPlanted + amountOfDays;

        if (m_daysPlanted >= m_plantedSeed.daysForFinalPlant)
        {
            SetCanBeHarvested(true);
            //SetFarmingTileStatus(FarmingTileStatus.Crops);
        }
    }

    public void ResetPlantedCrop()
    {
        m_canBeHarvested = false;
        // farmingTileStatus = FarmingTileStatus.Tilled;
        m_plantedSeed = null;
        m_daysPlanted = 0;

        //Change Sprites on the CropsTileManager
        Manager.cropsTileManager.UpdateCropTiles();
    }
}

public enum FarmingTileStatus
{
    Basic,
    Tilled,
    TilledAndWatered,
    Planted,
    PlantedAndWatered,
    Crops
}

public enum TileType
{
    Grass,
    Stone,
    Snow,
    Wall,
}

public enum CanBeFarmedTiles
{
    Grass,
    Snow
}
