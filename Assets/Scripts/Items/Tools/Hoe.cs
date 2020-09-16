using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Hoe", menuName = "Inventory/Tools/Hoe")]
public class Hoe : Tool
{

    public override void Grass(GameTile currentTile) {

        if (currentTile.GetIsTilled() == false)
        {
            //Change the sprite 
            Manager.gameTileManager.TillGrass(currentTile.GetX(), currentTile.GetY());
            //Change the tile data
            currentTile.SetIsTilled(true);

            //Sound of tilling grass
        }
        else {
            //Do nothing and make thump sound
        }
   
    }

}
