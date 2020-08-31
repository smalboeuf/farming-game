using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CropsTileManager : MonoBehaviour
{

    public CropTile[,] cropTileMap;
    [SerializeField] private Tilemap tilemap;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void LoadCrops() {

        cropTileMap = new CropTile[Manager.gameTileManager.GetXSize(), Manager.gameTileManager.GetYSize()];
        tilemap = GetComponent<Tilemap>();

        for (int x = 0; x < Manager.gameTileManager.GetXSize(); x++) {
            for (int y = 0; y < Manager.gameTileManager.GetYSize(); y++) {
                if (Manager.gameTileManager.gameTileMap[x, y].GetPlantedSeed()) {
                    //Set the appropriate tilemap sprite to the appropriate seed

                }
            }
        }
    }
}
