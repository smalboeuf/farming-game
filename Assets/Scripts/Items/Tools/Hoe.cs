using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Hoe", menuName = "Inventory/Tools/Hoe")]
public class Hoe : Tool
{

    public GameTileManager gameTileManager;

    public override void UseTool()
    {
        //Get position of the mouse 

        //Farm the specific block using gametilemanager

        //gameTileManager.UseHoeOnTile(int xPos, int yPos);
        Debug.Log("Used a Hoe");
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
