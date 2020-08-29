using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameTileManager : MonoBehaviour
{

    [SerializeField] int xSize;
    [SerializeField] int ySize;

    public static GameTile[,] gameTileMap;

    [SerializeField] private Tilemap tilemap;

    [SerializeField] private List<Tile> grassList;
    [SerializeField] private List<Tile> snowList;
    [SerializeField] private List<Tile> canBeHarvestedTiles;

    [SerializeField] private List<Tile> basicFarmTiles;
    [SerializeField] private List<Tile> tilledFarmTiles;
    [SerializeField] private List<Tile> tilledAndWateredFarmTiles;
    [SerializeField] private List<Tile> plantedFarmTiles;
    [SerializeField] private List<Tile> plantedAndWateredFarmTiles;
    [SerializeField] private List<Tile> cropsFarmTiles;

 

    // Start is called before the first frame update
    void Start()
    {
        gameTileMap = new GameTile[xSize, ySize];
        tilemap = GetComponent<Tilemap>();

        for (int x = 0; x < xSize; x++) {
            for (int y = 0; y < ySize; y++) {

                gameTileMap[x, y] = new GameTile(x, y, FindTileType(x, y), FindIfCanBeFarmed(x, y), FindIfCanBeHarvested(x,y), FindFarmingTileStatus(x, y));
            }   
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            
            Vector3 clickedPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
 

            if ((int)clickedPosition.x > 0 && (int)clickedPosition.y > 0) {
                if (gameTileMap[(int)clickedPosition.x, (int)clickedPosition.y].GetTileType() == TileType.Grass)
                {
                   // Debug.Log("Grass");
                }
            }


        }
    }

    private TileType FindTileType(int xPos, int yPos) {

        if (grassList.Contains((Tile)tilemap.GetTile(new Vector3Int(xPos, yPos, 0))))
        {
            return TileType.Grass;
        }
        else {
            return TileType.Stone;
        } 

    }



    private bool FindIfCanBeHarvested(int xPos, int yPos)
    {
        return canBeHarvestedTiles.Contains((Tile)tilemap.GetTile(new Vector3Int(xPos, yPos, 0)));
    }


    private bool FindIfCanBeFarmed(int xPos, int yPos) {

        //Check for each tile type that can farm

        if (IsAGrassTile(xPos, yPos)) {
            return true;
        }

        if (IsASnowTile(xPos, yPos)) {
            return true;
        }

        return false;
    }

    private FarmingTileStatus FindFarmingTileStatus(int xPos, int yPos) {
   

        if (IsATilledFarmTile(xPos, yPos)) {
            return FarmingTileStatus.Tilled;

        } else if (IsATilledAndWateredFarmTile(xPos, yPos))
        {
            return FarmingTileStatus.TilledAndWatered;

        } else if (IsAPlantedFarmTile(xPos, yPos))
        {
            return FarmingTileStatus.Planted;

        } else if (IsAPlantedAndWateredFarmTile(xPos, yPos))
        {
            return FarmingTileStatus.PlantedAndWatered;

        } else if (IsACropsFarmTile(xPos, yPos)) {

            return FarmingTileStatus.Crops;

        } else {
            return FarmingTileStatus.Basic;
        }

    }

    private bool IsABasicFarmTile(int xPos, int yPos) {
        return basicFarmTiles.Contains((Tile)tilemap.GetTile(new Vector3Int(xPos, yPos, 0)));
    }

    private bool IsATilledFarmTile(int xPos, int yPos)
    {
        return tilledFarmTiles.Contains((Tile)tilemap.GetTile(new Vector3Int(xPos, yPos, 0)));
    }

    private bool IsATilledAndWateredFarmTile(int xPos, int yPos)
    {
        return tilledAndWateredFarmTiles.Contains((Tile)tilemap.GetTile(new Vector3Int(xPos, yPos, 0)));
    }

    private bool IsAPlantedFarmTile(int xPos, int yPos)
    {
        return plantedFarmTiles.Contains((Tile)tilemap.GetTile(new Vector3Int(xPos, yPos, 0)));
    }

    private bool IsAPlantedAndWateredFarmTile(int xPos, int yPos)
    {
        return plantedAndWateredFarmTiles.Contains((Tile)tilemap.GetTile(new Vector3Int(xPos, yPos, 0)));
    }

    private bool IsACropsFarmTile(int xPos, int yPos)
    {
        return cropsFarmTiles.Contains((Tile)tilemap.GetTile(new Vector3Int(xPos, yPos, 0)));
    }

    private bool IsAGrassTile(int xPos, int yPos) {
        return grassList.Contains((Tile)tilemap.GetTile(new Vector3Int(xPos, yPos, 0)));
    }

    private bool IsASnowTile(int xPos, int yPos) {
        return snowList.Contains((Tile)tilemap.GetTile(new Vector3Int(xPos, yPos, 0)));
    }


    //Tools

    public void UseHoeOnTile(int xPos, int yPos) {
        if (CoordinatesAreValid(xPos, yPos))
        {
           
        }
    }


    private bool CoordinatesAreValid(int xPos, int yPos) {
        if (xPos > 0 && yPos > 0)
        {
            return true;
        }
        else {
            return false;
        }
    }

}
