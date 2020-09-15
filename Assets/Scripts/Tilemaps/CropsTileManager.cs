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

    // Update is called once per frame
    void Update()
    {
        
    }


    public void LoadCrops() {


        for (int x = 0; x < Manager.gameTileManager.GetXSize(); x++) {
            for (int y = 0; y < Manager.gameTileManager.GetYSize(); y++) {
                if (Manager.gameTileManager.gameTileMap[x, y].GetPlantedSeed() != null) {
                    //Set the appropriate tilemap sprite to the appropriate seed
                    Seed currentPlantedSeed = Manager.gameTileManager.gameTileMap[x, y].GetPlantedSeed();
                    GameTile currentTile = Manager.gameTileManager.gameTileMap[x, y];

                    if (currentTile.GetDaysPlanted() < currentPlantedSeed.GetDaysForMidPlant())
                    {
                        cropTilemap.SetTile(new Vector3Int(x, y, 0), currentPlantedSeed.GetPlantedTile());
                    }
                    else if (currentTile.GetDaysPlanted() < currentPlantedSeed.GetDaysForMidPlant() && currentTile.GetDaysPlanted() < currentPlantedSeed.GetDaysForFinalPlant())
                    {
                        cropTilemap.SetTile(new Vector3Int(x, y, 0), currentPlantedSeed.GetMidPlantedTile());
                    }
                    else if (currentTile.GetDaysPlanted() >= currentPlantedSeed.GetDaysForFinalPlant())
                    {
                        cropTilemap.SetTile(new Vector3Int(x, y, 0), currentPlantedSeed.GetFinalPlantedTile());
                    }
                    

                }
            }
        }
    }


    public void PlantSeed(Seed seed, int xPos, int yPos) {
        //Set tile
        cropTilemap.SetTile(new Vector3Int(xPos, yPos, 0), seed.GetPlantedTile());
        //Change FarmingTileStatusOfTile
        if (Manager.gameTileManager.gameTileMap[xPos, yPos].GetFarmingTileStatus() == FarmingTileStatus.Tilled)
        {
            Manager.gameTileManager.gameTileMap[xPos, yPos].SetFarmingTileStatus(FarmingTileStatus.Planted);
            Manager.gameTileManager.gameTileMap[xPos, yPos].SetPlantedSeed(seed);
        }
        else if (Manager.gameTileManager.gameTileMap[xPos, yPos].GetFarmingTileStatus() == FarmingTileStatus.TilledAndWatered) {
            Manager.gameTileManager.gameTileMap[xPos, yPos].SetFarmingTileStatus(FarmingTileStatus.PlantedAndWatered);
            Manager.gameTileManager.gameTileMap[xPos, yPos].SetPlantedSeed(seed);
        }

    }
    
    public void IncreaseCropDays(int amountOfDays)
    {
        for (int x = 0; x < Manager.gameTileManager.GetXSize(); x++)
        {
            for (int y = 0; y < Manager.gameTileManager.GetYSize(); y++)
            {
                //Check if a seed is planted
                if (Manager.gameTileManager.gameTileMap[x, y].GetPlantedSeed() != null && Manager.gameTileManager.gameTileMap[x, y].GetFarmingTileStatus() == FarmingTileStatus.PlantedAndWatered) {
                    Manager.gameTileManager.gameTileMap[x, y].IncreaseDaysPlanted(amountOfDays);
                }
            }
        }
    }

    public void UpdateCropTiles()
    {
        for (int x = 0; x < Manager.gameTileManager.GetXSize(); x++)
        {
            for (int y = 0; y < Manager.gameTileManager.GetYSize(); y++)
            {
                GameTile currentTile = Manager.gameTileManager.gameTileMap[x, y];

                if (currentTile.GetPlantedSeed() != null)
                {
                    Seed currentSeed = currentTile.GetPlantedSeed();


                    //Check if seed daysPlanted is equal to the mid or final point

                    if (currentTile.GetDaysPlanted() >= currentTile.GetPlantedSeed().GetDaysForMidPlant() && currentTile.GetDaysPlanted() < currentTile.GetPlantedSeed().GetDaysForFinalPlant())
                    {
                        //Set the tile to the mid tile
                        cropTilemap.SetTile(new Vector3Int(x, y, 0), currentSeed.GetMidPlantedTile());
                    }

                    if (currentTile.GetDaysPlanted() >= currentTile.GetPlantedSeed().GetDaysForFinalPlant())
                    {
                        //Set the tile to the final tile
                        cropTilemap.SetTile(new Vector3Int(x, y, 0), currentSeed.GetFinalPlantedTile());

                    }
                    

                } else {
                    cropTilemap.SetTile(new Vector3Int(x, y, 0), null);

                }

            }
        }
    }
}
