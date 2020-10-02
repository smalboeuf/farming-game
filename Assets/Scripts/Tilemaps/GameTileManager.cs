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
    [SerializeField] private Tile everythingExceptTopRightBottomRightBottomLeft;
    [SerializeField] private Tile everythingExceptTopLeftTopRightBottomRight;
    [SerializeField] private Tile everythingExceptTopLeftBottomLeftTopRight;
    [SerializeField] private Tile everythingExceptTopLeftBottomLeftBottomRight;
    [SerializeField] private Tile everythingExceptTopRightAndBottom;
    [SerializeField] private Tile everythingExceptTopLeftAndBottom;
    [SerializeField] private Tile everythingExceptTopLeftAndRight;
    [SerializeField] private Tile everythingExceptBottomLeftAndRight;
    [SerializeField] private Tile everythingExceptLeftAndBottomRight;
    [SerializeField] private Tile everythingExceptLeftAndTopRight;
    [SerializeField] private Tile everythingExceptTopAndBottomLeft;
    [SerializeField] private Tile everythingExceptTopAndBottomRight;
    [SerializeField] private Tile everythingExceptTopRightAndBottomLeft;
    [SerializeField] private Tile everythingExceptTopLeftAndBottomRight;

    [Header("Watered Tilled Tiles")]
    [SerializeField] private Tile soloTillTileWatered;
    [SerializeField] private Tile leftUpTopLeftWatered;
    [SerializeField] private Tile leftTileWatered;
    [SerializeField] private Tile rightTileWatered;
    [SerializeField] private Tile bottomTileWatered;
    [SerializeField] private Tile upTileWatered;
    [SerializeField] private Tile leftBottomTileWatered;
    [SerializeField] private Tile rightBottomTileWatered;
    [SerializeField] private Tile rightUpTopRightTileWatered;
    [SerializeField] private Tile allDirectionsTileWatered;
    [SerializeField] private Tile upBottomLeftRightTileWatered;
    [SerializeField] private Tile leftBottomBottomLeftTileWatered;
    [SerializeField] private Tile rightBottomBottomRightTileWatered;
    [SerializeField] private Tile rightTopTileWatered;
    [SerializeField] private Tile leftTopTileWatered;
    [SerializeField] private Tile rightLeftUpTopRightTopLeftTileWatered;
    [SerializeField] private Tile rightLeftBottomBottomRightBottomLeftTileWatered;
    [SerializeField] private Tile topBottomLeftTopLeftBottomLeftTileWatered;
    [SerializeField] private Tile topBottomRightTopRightBottomRightTileWatered;
    [SerializeField] private Tile everythingExceptBottomRightWatered;
    [SerializeField] private Tile everythingExceptBottomLeftWatered;
    [SerializeField] private Tile everythingExceptTopRightWatered;
    [SerializeField] private Tile everythingExceptTopLeftWatered;
    [SerializeField] private Tile everythingExceptTopLeftAndBottomLeftWatered;
    [SerializeField] private Tile everythingExceptTopRightAndBottomRightWatered;
    [SerializeField] private Tile everythingExceptTopRightAndTopLeftWatered;
    [SerializeField] private Tile everythingExceptBottomRightAndBottomLeftWatered;
    [SerializeField] private Tile topAndBottomTileWatered;
    [SerializeField] private Tile leftAndRightTileWatered;
    [SerializeField] private Tile leftRightTopNotTopRightLeftWatered;
    [SerializeField] private Tile leftRightBottomNotBottomRightLeftWatered;
    [SerializeField] private Tile topBottomRightNotTopRightBottomRightWatered;
    [SerializeField] private Tile topBottomLeftNotTopLeftBottomLeftWatered;
    [SerializeField] private Tile everythingExceptTopRightBottomRightBottomLeftWatered;
    [SerializeField] private Tile everythingExceptTopLeftTopRightBottomRightWatered;
    [SerializeField] private Tile everythingExceptTopLeftBottomLeftTopRightWatered;
    [SerializeField] private Tile everythingExceptTopLeftBottomLeftBottomRightWatered;
    [SerializeField] private Tile everythingExceptTopRightAndBottomWatered;
    [SerializeField] private Tile everythingExceptTopLeftAndBottomWatered;
    [SerializeField] private Tile everythingExceptTopLeftAndRightWatered;
    [SerializeField] private Tile everythingExceptBottomLeftAndRightWatered;
    [SerializeField] private Tile everythingExceptLeftAndBottomRightWatered;
    [SerializeField] private Tile everythingExceptLeftAndTopRightWatered;
    [SerializeField] private Tile everythingExceptTopAndBottomLeftWatered;
    [SerializeField] private Tile everythingExceptTopAndBottomRightWatered;
    [SerializeField] private Tile everythingExceptTopRightAndBottomLeftWatered;
    [SerializeField] private Tile everythingExceptTopLeftAndBottomRightWatered;





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


    public bool IsAValidTile(int xPos, int yPos) {

        if (xPos >= 0 && yPos >= 0 && xPos < xSize && yPos < ySize) {
            return true;
        }

        return false;
    }


    private void UpdateTileSprite(int xPos, int yPos)
    {
        
        bool currentTileIsTilled = Manager.gameTileManager.gameTileMap[xPos, yPos].GetIsTilled();
        bool currentTileIsWatered = Manager.gameTileManager.gameTileMap[xPos, yPos].GetIsWatered();

        bool one = false;
        bool two = false;
        bool three = false;
        bool four = false;
        bool five = false;
        bool six = false;
        bool seven = false;
        bool eight = false;

        if (xPos - 1 < 0 || xPos + 1 >= xSize || yPos - 1 < 0 || yPos + 1 >= ySize)
        {
            currentTileIsTilled = false;
        }
        else {

           one = Manager.gameTileManager.gameTileMap[xPos - 1, yPos + 1].GetIsTilled();
           two = Manager.gameTileManager.gameTileMap[xPos, yPos + 1].GetIsTilled();
           three = Manager.gameTileManager.gameTileMap[xPos + 1, yPos + 1].GetIsTilled();
           four = Manager.gameTileManager.gameTileMap[xPos - 1, yPos].GetIsTilled();
           five = Manager.gameTileManager.gameTileMap[xPos + 1, yPos].GetIsTilled();
           six = Manager.gameTileManager.gameTileMap[xPos - 1, yPos - 1].GetIsTilled();
           seven = Manager.gameTileManager.gameTileMap[xPos, yPos - 1].GetIsTilled();
           eight = Manager.gameTileManager.gameTileMap[xPos + 1, yPos - 1].GetIsTilled();
        }
     

        if (currentTileIsTilled)
        {


            if (two && seven && !four && !five)
            {
                if (currentTileIsWatered)
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), topAndBottomTileWatered);
                }
                else {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), topAndBottomTile);
                }

            }
            else if (four && five && !two && !seven)
            {
                if (currentTileIsWatered)
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), leftAndRightTileWatered);
                }
                else
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), leftAndRightTile);
                }


            }
            else if (one && two && four && seven && five && !three && !eight && !six)
            {
                if (currentTileIsWatered)
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), everythingExceptTopRightBottomRightBottomLeftWatered);
                }
                else
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), everythingExceptTopRightBottomRightBottomLeft);
                }

            }
            else if (!one && !three && !eight && two && four && six && seven && five)
            {
                if (currentTileIsWatered)
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), everythingExceptTopLeftTopRightBottomRightWatered);
                }
                else
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), everythingExceptTopLeftTopRightBottomRight);
                }

            }
            else if (!four && !eight && two && three && five && seven)
            {

                if (currentTileIsWatered)
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), everythingExceptLeftAndBottomRightWatered);
                }
                else
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), everythingExceptLeftAndBottomRight);
                }
            }
            else if (!one && !three && !six && two && four && five && eight && seven)
            {
                if (currentTileIsWatered)
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), everythingExceptTopLeftBottomLeftTopRightWatered);
                }
                else
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), everythingExceptTopLeftBottomLeftTopRight);
                }

            }
            else if (!one && !six && !eight && two && three && five && four && seven)
            {
                if (currentTileIsWatered)
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), everythingExceptTopLeftBottomLeftBottomRightWatered);
                }
                else
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), everythingExceptTopLeftBottomLeftBottomRight);
                }

            }
            else if (!seven && !three && one && two && four && five)
            {
                if (currentTileIsWatered)
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), everythingExceptTopRightAndBottomWatered);
                }
                else
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), everythingExceptTopRightAndBottom);
                }

            }
            else if (!one && !seven && two && three && five && four)
            {
                if (currentTileIsWatered)
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), everythingExceptTopLeftAndBottomWatered);
                }
                else
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), everythingExceptTopLeftAndBottom);
                }

            }
            else if (!one && !five && two && four && six && seven)
            {
                if (currentTileIsWatered)
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), everythingExceptTopLeftAndRightWatered);
                }
                else
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), everythingExceptTopLeftAndRight);
                }

            }
            else if (!six && !five && two && one && four && seven)
            {
                if (currentTileIsWatered)
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), everythingExceptBottomLeftAndRightWatered);
                }
                else
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), everythingExceptBottomLeftAndRight);
                }

            }
            else if (!four && !eight && two && three && five && seven)
            {
                if (currentTileIsWatered)
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), leftAndRightTileWatered);
                }
                else
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), leftAndRightTile);
                }

            }
            else if (!four && !three && two && five && eight && seven)
            {
                if (currentTileIsWatered)
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), everythingExceptLeftAndTopRightWatered);
                }
                else
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), everythingExceptLeftAndTopRight);
                }

            }
            else if (!two && !six && five && seven && eight && four)
            {
                if (currentTileIsWatered)
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), everythingExceptTopAndBottomLeftWatered);
                }
                else
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), everythingExceptTopAndBottomLeft);
                }

            }
            else if (!two && !eight && five && seven && six && four)
            {
                if (currentTileIsWatered)
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), everythingExceptTopAndBottomRightWatered);
                }
                else
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), everythingExceptTopAndBottomRight);
                }

            }
            else if (!six && !three && two && one && four && five && eight && seven)
            {
                if (currentTileIsWatered)
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), everythingExceptTopRightAndBottomLeftWatered);
                }
                else
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), everythingExceptTopRightAndBottomLeft);
                }

            }
            else if (!one && !eight && two && three && five && four && six && seven)
            {
                if (currentTileIsWatered)
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), everythingExceptTopLeftAndBottomRightWatered);
                }
                else
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), everythingExceptTopLeftAndBottomRight);
                }

            }
            else if (one && two && three && four && five && six && seven && !eight)
            {
                if (currentTileIsWatered)
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), everythingExceptBottomRightWatered);
                }
                else
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), everythingExceptBottomRight);
                }

            }
            else if (!one && two && three && four && five && six && seven && eight)
            {
                if (currentTileIsWatered)
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), everythingExceptTopLeftWatered);
                }
                else
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), everythingExceptTopLeft);
                }

            }
            else if (one && two && !three && four && five && six && seven && eight)
            {
                if (currentTileIsWatered)
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), everythingExceptTopRightWatered);
                }
                else
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), everythingExceptTopRight);
                }

            }
            else if (one && two && three && four && five && !six && seven && eight)
            {
                if (currentTileIsWatered)
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), everythingExceptBottomLeftWatered);
                }
                else
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), everythingExceptBottomLeft);
                }

            }
            else if (!one && two && three && four && five && !six && seven && eight)
            {
                if (currentTileIsWatered)
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), everythingExceptTopLeftAndBottomLeftWatered);
                }
                else
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), everythingExceptTopLeftAndBottomLeft);
                }

            }
            else if (one && two && three && four && five && !six && seven && !eight)
            {
                if (currentTileIsWatered)
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), everythingExceptBottomRightAndBottomLeftWatered);
                }
                else
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), everythingExceptBottomRightAndBottomLeft);
                }

            }
            else if (one && two && !three && four && five && six && seven && !eight)
            {
                if (currentTileIsWatered)
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), everythingExceptTopRightAndBottomRightWatered);
                }
                else
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), everythingExceptTopRightAndBottomRight);
                }

            }
            else if (!one && two && !three && four && five && six && seven && eight)
            {
                if (currentTileIsWatered)
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), everythingExceptTopRightAndTopLeftWatered);
                }
                else
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), everythingExceptTopRightAndTopLeft);
                }

            }
            else if (four && five && two && !one && !three && !seven)
            {
                if (currentTileIsWatered)
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), leftRightTopNotTopRightLeftWatered);
                }
                else
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), leftRightTopNotTopRightLeft);
                }

            }
            else if (!two && five && four && seven && !six && !eight)
            {
                if (currentTileIsWatered)
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), leftRightBottomNotBottomRightLeftWatered);
                }
                else
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), leftRightBottomNotBottomRightLeft);
                }

            }
            else if (!four && !three && !eight && two && seven && five)
            {
                if (currentTileIsWatered)
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), topBottomRightNotTopRightBottomRightWatered);
                }
                else
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), topBottomRightNotTopRightBottomRight);
                }

            }
            else if (!one && !six && !five && two && seven && four)
            {
                if (currentTileIsWatered)
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), topBottomLeftNotTopLeftBottomLeftWatered);
                }
                else
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), topBottomLeftNotTopLeftBottomLeft);
                }

            }
            else if (!six && !two && !five && four && seven)
            {
                if (currentTileIsWatered)
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), leftBottomTileWatered);
                }
                else
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), leftBottomTile);
                }

            }
            else if (!two && !four && eight && seven && five)
            {
                if (currentTileIsWatered)
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), rightBottomBottomRightTileWatered);
                }
                else
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), rightBottomBottomRightTile);
                }

            }
            else if (!two && four && five && six && seven && eight)
            {
                if (currentTileIsWatered)
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), rightLeftBottomBottomRightBottomLeftTileWatered);
                }
                else
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), rightLeftBottomBottomRightBottomLeftTile);
                }

            }
            else if (!two && !five && four && six && seven)
            {
                if (currentTileIsWatered)
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), leftBottomBottomLeftTileWatered);
                }
                else
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), leftBottomBottomLeftTile);
                }

            }
            else if (!one && two && four && !five && !seven)
            {
                if (currentTileIsWatered)
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), leftTopTileWatered);
                }
                else
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), leftTopTile);
                }

            }
            else if (!four && two && seven && three && five && eight)
            {
                if (currentTileIsWatered)
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), topBottomRightTopRightBottomRightTileWatered);
                }
                else
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), topBottomRightTopRightBottomRightTile);
                }

            }
            else if (one && two && three && four && five && six && seven && eight)
            {
                if (currentTileIsWatered)
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), allDirectionsTileWatered);
                }
                else
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), allDirectionsTile);
                }

            }
            else if (!five && two && seven && four && one && six)
            {
                if (currentTileIsWatered)
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), topBottomLeftTopLeftBottomLeftTileWatered);
                }
                else
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), topBottomLeftTopLeftBottomLeftTile);
                }

            }
            else if (!two && !four && !eight && seven && five)
            {
                if (currentTileIsWatered)
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), rightBottomTileWatered);
                }
                else
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), rightBottomTile);
                }

            }
            else if (!one && two && !three && four && five && !six && seven && !eight)
            {
                if (currentTileIsWatered)
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), upBottomLeftRightTileWatered);
                }
                else
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), upBottomLeftRightTile);
                }

            }
            else if (!four && !seven && two && three && five)
            {
                if (currentTileIsWatered)
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), rightUpTopRightTileWatered);
                }
                else
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), rightUpTopRightTile);
                }

            }
            else if (!seven && four && five && two && one && three)
            {
                if (currentTileIsWatered)
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), rightLeftUpTopRightTopLeftTileWatered);
                }
                else
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), rightLeftUpTopRightTopLeftTile);
                }

            }
            else if (!five && !seven && four && one && two)
            {
                if (currentTileIsWatered)
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), leftUpTopLeftWatered);
                }
                else
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), leftUpTopLeft);
                }

            }
            else if (!three && !four && !seven && two && five)
            {
                if (currentTileIsWatered)
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), rightTopTileWatered);
                }
                else
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), rightTopTile);
                }

            }
            else if (!two && !four && !seven && !five)
            {
                if (currentTileIsWatered)
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), soloTillTileWatered);
                }
                else
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), soloTillTile);
                }

            }
            else if (!two && !four && !seven && five)
            {
                if (currentTileIsWatered)
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), rightTileWatered);
                }
                else
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), rightTile);
                }

            }
            else if (!two && !five && !seven && four)
            {
                if (currentTileIsWatered)
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), leftTileWatered);
                }
                else
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), leftTile);
                }

            }
            else if (!two && !four && !five && seven)
            {
                if (currentTileIsWatered)
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), bottomTileWatered);
                }
                else
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), bottomTile);
                }

            }
            else if (two && !four && !five && !seven)
            {
                if (currentTileIsWatered)
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), upTileWatered);
                }
                else
                {
                    tilemap.SetTile(new Vector3Int(xPos, yPos, 0), upTile);
                }

            }
            else
            {

                //Do nothing

            }
        }

        
    }


    public void ResetGameTileIsWatered() {

        for (int x = 0; x < xSize; x++)
        {
            for (int y = 0; y < ySize; y++)
            {
                gameTileMap[x, y].SetIsWatered(false);
                UpdateTileSprite(x, y);
            }
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

    private bool IsAGrassTile(int xPos, int yPos) {
        return grassList.Contains((Tile)tilemap.GetTile(new Vector3Int(xPos, yPos, 0)));
    }

    private bool IsASnowTile(int xPos, int yPos) {
        return snowList.Contains((Tile)tilemap.GetTile(new Vector3Int(xPos, yPos, 0)));
    }




    //Tools

    public void TillGrass(int xPos, int yPos) {
        
        //Set tile status
        Manager.gameTileManager.gameTileMap[xPos, yPos].SetIsTilled(true);

        UpdateTileSprite(xPos, yPos);
        UpdateTileSprite(xPos - 1, yPos + 1);
        UpdateTileSprite(xPos, yPos + 1);
        UpdateTileSprite(xPos + 1, yPos + 1);
        UpdateTileSprite(xPos - 1, yPos);
        UpdateTileSprite(xPos + 1, yPos);
        UpdateTileSprite(xPos - 1, yPos - 1);
        UpdateTileSprite(xPos, yPos - 1);
        UpdateTileSprite(xPos + 1, yPos -1);
    }

    public void WaterTilledTile(int xPos, int yPos) {

        GameTile currentTile = Manager.gameTileManager.gameTileMap[xPos, yPos];

        currentTile.SetIsWatered(true);
        UpdateTileSprite(xPos, yPos);
        UpdateTileSprite(xPos - 1, yPos + 1);
        UpdateTileSprite(xPos, yPos + 1);
        UpdateTileSprite(xPos + 1, yPos + 1);
        UpdateTileSprite(xPos - 1, yPos);
        UpdateTileSprite(xPos + 1, yPos);
        UpdateTileSprite(xPos - 1, yPos - 1);
        UpdateTileSprite(xPos, yPos - 1);
        UpdateTileSprite(xPos + 1, yPos - 1);

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
