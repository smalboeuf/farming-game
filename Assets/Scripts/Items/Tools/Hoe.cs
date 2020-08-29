using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Hoe", menuName = "Inventory/Tools/Hoe")]
public class Hoe : Tool
{

    public override void Grass(GameTile currentTile) {

        if (currentTile.GetFarmingTileStatus() == FarmingTileStatus.Basic) {
            //Change the sprite 
            Manager.gameTileManager.TillGrass(currentTile.GetX(), currentTile.GetY());
            //Change the tile data
            currentTile.SetCanBeTilled(false);

        
            //Sound of tilling grass
        }
        else if (currentTile.GetFarmingTileStatus() == FarmingTileStatus.Tilled)
        {
            //Do nothing, thump sound
        }
        else if (currentTile.GetFarmingTileStatus() == FarmingTileStatus.TilledAndWatered)
        {
            //Do nothing, thump sound
        }
        else if (currentTile.GetFarmingTileStatus() == FarmingTileStatus.Planted)
        {
            //Destroy current planted crop
        }
        else if (currentTile.GetFarmingTileStatus() == FarmingTileStatus.PlantedAndWatered)
        {
            //Destroy current planted crop
        }
        else if (currentTile.GetFarmingTileStatus() == FarmingTileStatus.Crops)
        {
            //Do nothing, thump sound
        }
    }

}
