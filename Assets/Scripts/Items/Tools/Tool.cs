using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tool : InventoryItem
{

    public virtual void Grass(GameTile currentTile) { }
    public virtual void Stone(GameTile currentTile) { }
    public virtual void Wall(GameTile currentTile) { }


    public void UseTool(int xPos, int yPos) {
       GameTile currentTile = GameTileManager.gameTileMap[xPos, yPos];

        switch (currentTile.GetTileType())
        {
            case TileType.Grass:
                Grass(currentTile);
                break;

            case TileType.Stone:
                Stone(currentTile);
                break;

            case TileType.Wall:
                Wall(currentTile);
                break;

            default:
                Debug.Log("TileType not found.");
                break;
        
        }
    }
}
