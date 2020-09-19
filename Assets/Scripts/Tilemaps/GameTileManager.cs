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

    [SerializeField] private Tile topAndBottomTile;
    [SerializeField] private Tile leftAndRightTile;

    [SerializeField] private Tile leftRightTopNotTopRightLeft;
    [SerializeField] private Tile leftRightBottomNotBottomRightLeft;
    [SerializeField] private Tile topBottomRightNotTopRightBottomRight;
    [SerializeField] private Tile topBottomLeftNotTopLeftBottomLeft;



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
        bool one = Manager.gameTileManager.gameTileMap[xPos - 1, yPos + 1].GetIsTilled();
        bool two = Manager.gameTileManager.gameTileMap[xPos, yPos + 1].GetIsTilled();
        bool three = Manager.gameTileManager.gameTileMap[xPos + 1, yPos + 1].GetIsTilled();
        bool four = Manager.gameTileManager.gameTileMap[xPos - 1, yPos].GetIsTilled();
        bool five = Manager.gameTileManager.gameTileMap[xPos + 1, yPos].GetIsTilled(); 
        bool six = Manager.gameTileManager.gameTileMap[xPos - 1, yPos - 1].GetIsTilled(); 
        bool seven = Manager.gameTileManager.gameTileMap[xPos, yPos - 1].GetIsTilled();
        bool eight = Manager.gameTileManager.gameTileMap[xPos + 1, yPos - 1].GetIsTilled();


        //29 total

        if (two && seven && !four && !five)
        {
            tilemap.SetTile(new Vector3Int(xPos, yPos, 0), topAndBottomTile);
        }
        else if (four && five && !two && !seven)
        {
            tilemap.SetTile(new Vector3Int(xPos, yPos, 0), leftAndRightTile);
        }
        else if (!two && !four && !seven && five)
        {
            tilemap.SetTile(new Vector3Int(xPos, yPos, 0), rightTile);
        }
        else if (!two && !five && !seven && four)
        {
            tilemap.SetTile(new Vector3Int(xPos, yPos, 0), leftTile);
        }
        else if (!two && !four && !five && seven)
        {
            tilemap.SetTile(new Vector3Int(xPos, yPos, 0), bottomTile);
        }
        else if (two && !four && !five && !seven)
        {
            tilemap.SetTile(new Vector3Int(xPos, yPos, 0), upTile);
        }
        else if (!six && !two && !five && four && seven)
        {
            tilemap.SetTile(new Vector3Int(xPos, yPos, 0), leftBottomTile);
        }
        else if (!two && !four && eight && seven && five)
        {
            tilemap.SetTile(new Vector3Int(xPos, yPos, 0), rightBottomBottomRightTile);
        }
        else if (!two && four && five && six && seven && eight)
        {
            tilemap.SetTile(new Vector3Int(xPos, yPos, 0), rightLeftBottomBottomRightBottomLeftTile);
        }
        else if (!two && !five && four && six && seven)
        {
            tilemap.SetTile(new Vector3Int(xPos, yPos, 0), leftBottomBottomLeftTile);
        }
        else if (!one && two && four && !five && !seven)
        {
            tilemap.SetTile(new Vector3Int(xPos, yPos, 0), leftTopTile);
        }
        else if (!four && two && seven && three && five && eight)
        {
            tilemap.SetTile(new Vector3Int(xPos, yPos, 0), topBottomRightTopRightBottomRightTile);
        }
        else if (one && two && three && four && five && six && seven && eight) {

            tilemap.SetTile(new Vector3Int(xPos, yPos, 0), allDirectionsTile);

        } else if (!five && two && seven && four && one && six)
        {
            tilemap.SetTile(new Vector3Int(xPos, yPos, 0), topBottomLeftTopLeftBottomLeftTile);
        }
        else if (!two && !four && !eight && seven && five)
        {
            tilemap.SetTile(new Vector3Int(xPos, yPos, 0), rightBottomTile);
        }
        else if (!one && two && !three && four && five && !six && seven && !eight)
        {
            tilemap.SetTile(new Vector3Int(xPos, yPos, 0), upBottomLeftRightTile);
        }
        else if (!four && !seven && two && three && five)
        {
            tilemap.SetTile(new Vector3Int(xPos, yPos, 0), rightUpTopRightTile);
        }
        else if (!seven && four && five && two && one && three)
        {
            tilemap.SetTile(new Vector3Int(xPos, yPos, 0), rightLeftUpTopRightTopLeftTile);
        }
        else if (!five && !seven && four && one && two)
        {
            tilemap.SetTile(new Vector3Int(xPos, yPos, 0), leftUpTopLeft);
        }
        else if (!three && !four && !seven && two && five)
        {
            tilemap.SetTile(new Vector3Int(xPos, yPos, 0), rightTopTile);
        }
        else if (one && two && three && four && five && six && seven && !eight)
        {
            tilemap.SetTile(new Vector3Int(xPos, yPos, 0), everythingExceptBottomRight);
        }
        else if (!one && two && three && four && five && six && seven && eight)
        {
            tilemap.SetTile(new Vector3Int(xPos, yPos, 0), everythingExceptTopLeft);
        }
        else if (one && two && !three && four && five && six && seven && eight)
        {
            tilemap.SetTile(new Vector3Int(xPos, yPos, 0), everythingExceptTopRight);
        }
        else if (one && two && three && four && five && !six && seven && eight)
        {
            tilemap.SetTile(new Vector3Int(xPos, yPos, 0), everythingExceptBottomLeft);
        }
        else if (!one && two && three && four && five && !six && seven && eight)
        {
            tilemap.SetTile(new Vector3Int(xPos, yPos, 0), everythingExceptTopLeftAndBottomLeft);
        }
        else if (one && two && three && four && five && !six && seven && !eight)
        {
            tilemap.SetTile(new Vector3Int(xPos, yPos, 0), everythingExceptBottomRightAndBottomLeft);
        }
        else if (one && two && !three && four && five && six && seven && !eight)
        {
            tilemap.SetTile(new Vector3Int(xPos, yPos, 0), everythingExceptTopRightAndBottomRight);
        }
        else if (one && two && three && four && five && six && seven && eight)
        {
            tilemap.SetTile(new Vector3Int(xPos, yPos, 0), everythingExceptTopRightAndTopLeft);
        }
        else if (four && five && two && !one && !three && !seven)
        {
            tilemap.SetTile(new Vector3Int(xPos, yPos, 0), leftRightTopNotTopRightLeft);
        }
        else if (!two && five && four && seven && !six && !eight)
        {
            tilemap.SetTile(new Vector3Int(xPos, yPos, 0), leftRightBottomNotBottomRightLeft);
        }
        else if (!four && !three && !eight && two && seven && five)
        {
            tilemap.SetTile(new Vector3Int(xPos, yPos, 0), topBottomRightNotTopRightBottomRight);
        }
        else if (!one && !six && !five && two && seven && four)
        {
            tilemap.SetTile(new Vector3Int(xPos, yPos, 0), topBottomLeftNotTopLeftBottomLeft);
        }
        else
        {
            tilemap.SetTile(new Vector3Int(xPos, yPos, 0), soloTillTile);
        }

        


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
