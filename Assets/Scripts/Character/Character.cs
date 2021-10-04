using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float range = 10f;
    int maxHP = 100;
    int currentHP = 90;
    int maxEnergy = 100;
    int currentEnergy = 100;

    bool canMove = true;

    public InventoryManager inventoryManager;
    public HotbarManager hotbarManager;
    public GameTileManager tileManager;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0) && canMove == true)
        {
            Vector3 clickedPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (hotbarManager.GetSelectedItem() is Tool tool)
            {

                if (IsInRange(clickedPosition) && IsAValidCoordinate((int)clickedPosition.x, (int)clickedPosition.y))
                {
                    tool.UseTool((int)clickedPosition.x, (int)clickedPosition.y);
                }
            }
        }
    }

    public bool GetCanMove()
    {
        return canMove;
    }

    public void SetCanMove(bool newCanMove)
    {
        canMove = newCanMove;
    }

    public bool CanPickUpItem(Vector3 pos)
    {

        GameTile currentTile = Manager.gameTileManager.gameTileMap[(int)pos.x, (int)pos.y];

        if (currentTile.GetCanBeHarvested() == true)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    public void HarvestCrop(Vector3 tilePos)
    {

        GameTile currentTile = Manager.gameTileManager.gameTileMap[(int)tilePos.x, (int)tilePos.y];
        Seed seedPlantedInTile = currentTile.GetPlantedSeed();

        //Add item to inventory
        Manager.inventoryManager.AddItem(seedPlantedInTile.GetCropForHarvesting(), 1);

        //Reset the crop
        currentTile.ResetPlantedCrop();
    }

    private bool IsInRange(Vector3 clickedPos)
    {

        if (Vector2.Distance(gameObject.transform.position, clickedPos) <= range)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Heal(int amount)
    {

        if (amount + currentHP > maxHP)
        {
            currentHP = maxHP;
        }
        else
        {
            currentHP = currentHP + amount;
        }
    }

    public bool IsAValidCoordinate(int xPos, int yPos)
    {
        if (xPos >= 0 && yPos >= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
