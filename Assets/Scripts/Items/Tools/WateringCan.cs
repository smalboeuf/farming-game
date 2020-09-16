using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Watering Can", menuName = "Inventory/Tools/WateringCan")]
public class WateringCan : Tool
{

    [SerializeField] private int maxAmountOfUses;
    [SerializeField] private int amountOfUses;


    public override void Grass(GameTile currentTile) {

        if (currentTile.GetIsTilled() == true)
        {
            //Do nothing, thump sound

            Manager.gameTileManager.WaterTilledTile(currentTile.GetX(), currentTile.GetY());
            currentTile.SetIsWatered(true);

        }
        else {
            //Do nothing and still make sounds
        }

    }
}
