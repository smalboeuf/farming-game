using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CropsTileManager : MonoBehaviour
{
    [SerializeField] private Tilemap cropTilemap;

    // Start is called before the first frame update
    void Start()
    {
        cropTilemap = GetComponent<Tilemap>();
    }

    public void LoadCrops()
    {


        for (int x = 0; x < Manager.gameTileManager.xSize; x++)
        {
            for (int y = 0; y < Manager.gameTileManager.ySize; y++)
            {
                if (Manager.gameTileManager.gameTileMap[x, y].plantedSeed != null)
                {
                    //Set the appropriate tilemap sprite to the appropriate seed
                    Seed currentPlantedSeed = Manager.gameTileManager.gameTileMap[x, y].plantedSeed;
                    GameTile currentTile = Manager.gameTileManager.gameTileMap[x, y];

                    if (currentTile.daysPlanted < currentPlantedSeed.daysForMidPlant)
                    {
                        cropTilemap.SetTile(new Vector3Int(x, y, 0), currentPlantedSeed.plantedTile);
                    }
                    else if (currentTile.daysPlanted < currentPlantedSeed.daysForMidPlant && currentTile.daysPlanted < currentPlantedSeed.daysForFinalPlant)
                    {
                        cropTilemap.SetTile(new Vector3Int(x, y, 0), currentPlantedSeed.midPlantedTile);
                    }
                    else if (currentTile.daysPlanted >= currentPlantedSeed.daysForFinalPlant)
                    {
                        cropTilemap.SetTile(new Vector3Int(x, y, 0), currentPlantedSeed.finalPlantedTile);
                    }
                }
            }
        }
    }

    public void PlantSeed(Seed seed, int xPos, int yPos)
    {
        //Set tile
        cropTilemap.SetTile(new Vector3Int(xPos, yPos, 0), seed.plantedTile);

        GameTile currentTile = Manager.gameTileManager.gameTileMap[xPos, yPos];
        //Change FarmingTileStatusOfTile
        if (currentTile.isTilled == true && currentTile.plantedSeed == null)
        {
            Manager.gameTileManager.gameTileMap[xPos, yPos].SetPlantedSeed(seed);
        }
    }

    public void IncreaseCropDays(int amountOfDays)
    {
        for (int x = 0; x < Manager.gameTileManager.xSize; x++)
        {
            for (int y = 0; y < Manager.gameTileManager.ySize; y++)
            {
                GameTile currentTile = Manager.gameTileManager.gameTileMap[x, y];

                //Check if a seed is planted
                if (currentTile.plantedSeed != null && currentTile.isTilled == true && currentTile.isWatered == true)
                {
                    Manager.gameTileManager.gameTileMap[x, y].IncreaseDaysPlanted(amountOfDays);
                }
            }
        }
    }

    public void UpdateCropTiles()
    {
        for (int x = 0; x < Manager.gameTileManager.xSize; x++)
        {
            for (int y = 0; y < Manager.gameTileManager.ySize; y++)
            {
                GameTile currentTile = Manager.gameTileManager.gameTileMap[x, y];

                if (currentTile.plantedSeed != null)
                {
                    Seed currentSeed = currentTile.plantedSeed;

                    //Check if seed daysPlanted is equal to the mid or final point

                    if (currentTile.daysPlanted >= currentTile.plantedSeed.daysForMidPlant && currentTile.daysPlanted < currentTile.plantedSeed.daysForFinalPlant)
                    {
                        //Set the tile to the mid tile
                        cropTilemap.SetTile(new Vector3Int(x, y, 0), currentSeed.midPlantedTile);
                    }

                    if (currentTile.daysPlanted >= currentTile.plantedSeed.daysForFinalPlant)
                    {
                        //Set the tile to the final tile
                        cropTilemap.SetTile(new Vector3Int(x, y, 0), currentSeed.finalPlantedTile);
                    }
                }
                else
                {
                    cropTilemap.SetTile(new Vector3Int(x, y, 0), null);

                }

            }
        }
    }
}
