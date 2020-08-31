using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CropsTileManager : MonoBehaviour
{

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
