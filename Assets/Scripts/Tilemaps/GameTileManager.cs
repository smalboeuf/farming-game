using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameTileManager : MonoBehaviour
{

    [SerializeField] int xSize;
    [SerializeField] int ySize;

    public GameTile[,] gameTileMap;

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

    [SerializeField] private Tile summerTilledTile;
    [SerializeField] private Tile summerTilledAndWateredFarmTile;

    [Header("Tilled Tiles")]
    [SerializeField] private Tile soloTillTile;
    [SerializeField] private Tile leftUpTopLeft;
    [SerializeField] private Tile leftTile;
    [SerializeField] private Tile rightTile;
    [SerializeField] private Tile bottomTile;
    [SerializeField] private Tile upTile;
    [SerializeField] private Tile leftBottomTile;
    [SerializeField] private Tile rightBottomTile;
    [SerializeField] private Tile rightUpTopRightTile;
    [SerializeField] private Tile allDirectionsTile;
    [SerializeField] private Tile upBottomLeftRightTile;
    [SerializeField] private Tile leftBottomBottomLeftTile;
    [SerializeField] private Tile rightBottomBottomRightTile;
    [SerializeField] private Tile rightTopTile;
    [SerializeField] private Tile leftTopTile;
    [SerializeField] private Tile rightLeftUpTopRightTopLeftTile;
    [SerializeField] private Tile rightLeftBottomBottomRightBottomLeftTile;
    [SerializeField] private Tile topBottomLeftTopLeftBottomLeftTile;
    [SerializeField] private Tile topBottomRightTopRightBottomRightTile;

    [SerializeField] private Tile everythingExceptBottomRight;
    [SerializeField] private Tile everythingExceptBottomLeft;
    [SerializeField] private Tile everythingExceptTopRight;
    [SerializeField] private Tile everythingExceptTopLeft;

    [SerializeField] private Tile everythingExceptTopLeftAndBottomLeft;
    [SerializeField] private Tile everythingExceptTopRightAndBottomRight;
    [SerializeField] private Tile everythingExceptTopRightAndTopLeft;
    [SerializeField] private Tile everythingExceptBottomRightAndBottomLeft;



    // Start is called before the first frame update
    void Start()
    {
        gameTileMap = new GameTile[xSize, ySize];
        tilemap = GetComponent<Tilemap>();

        for (int x = 0; x < xSize; x++) {
            for (int y = 0; y < ySize; y++) {

                gameTileMap[x, y] = new GameTile(x, y, FindTileType(x, y), FindIfIsTilled(x, y), FindIfCanBeHarvested(x, y), false, null, 0);
            }
        }

        Manager.cropsTileManager.LoadCrops();
    }

    // Update is called once per frame
    void Update()
    {

    }





    private void PlaceTilledTile(int xPos, int yPos)
    {

    }

    public int GetXSize()
    {
        return xSize;
    }

    public int GetYSize()
    {
        return ySize;
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


    private bool FindIfIsTilled(int xPos, int yPos) {

        //Check for each tile type that can farm

        if (IsAGrassTile(xPos, yPos)) {
            return false;
        }

        if (IsASnowTile(xPos, yPos)) {
            return false;
        }

        return true;
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

    public void TillGrass(int xPos, int yPos) {
        tilemap.SetTile(new Vector3Int(xPos, yPos, 0), summerTilledTile);
        //Set tile status
        Manager.gameTileManager.gameTileMap[xPos, yPos].SetIsTilled(true);
    }

    public void WaterTilledTile(int xPos, int yPos) {

        GameTile currentTile = Manager.gameTileManager.gameTileMap[xPos, yPos];

        tilemap.SetTile(new Vector3Int(xPos, yPos, 0), summerTilledAndWateredFarmTile);

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
