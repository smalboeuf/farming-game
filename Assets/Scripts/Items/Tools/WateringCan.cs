using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Watering Can", menuName = "Inventory/Tools/WateringCan")]
public class WateringCan : Tool
{

    [SerializeField] private int maxAmountOfUses;
    [SerializeField] private int amountOfUses;


    public override void Grass(GameTile currentTile) {


        if (currentTile.GetFarmingTileStatus() == FarmingTileStatus.Basic)
        {
            //Change the sprite 
            

            //Sound of tilling grass
        }
        else if (currentTile.GetFarmingTileStatus() == FarmingTileStatus.Tilled)
        {
            //Do nothing, thump sound

            Manager.gameTileManager.WaterTilledTile(currentTile.GetX(), currentTile.GetY());
            Manager.gameTileManager.gameTileMap[currentTile.GetX(), currentTile.GetY()].SetFarmingTileStatus(FarmingTileStatus.TilledAndWatered);
        }
        else if (currentTile.GetFarmingTileStatus() == FarmingTileStatus.TilledAndWatered)
        {
            //Do nothing, thump sound
        }
        else if (currentTile.GetFarmingTileStatus() == FarmingTileStatus.Planted)
        {
            //Destroy current planted crop
            Manager.gameTileManager.WaterTilledTile(currentTile.GetX(), currentTile.GetY());
            Manager.gameTileManager.gameTileMap[currentTile.GetX(), currentTile.GetY()].SetFarmingTileStatus(FarmingTileStatus.PlantedAndWatered);
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
