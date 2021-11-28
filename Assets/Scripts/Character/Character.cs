using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private CharacterProfile characterProfile;
    public float range = 10f;
    public Health characterHealth;
    public Energy characterEnergy;
    bool m_canMove = true;

    public bool CanMove => m_canMove;

    public InventoryManager inventoryManager;
    public HotbarManager hotbarManager;
    public GameTileManager tileManager;

    private void Start()
    {
        characterHealth = GetComponent<Health>();
        characterEnergy = GetComponent<Energy>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && m_canMove == true)
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

    public void SetCanMove(bool newCanMove)
    {
        m_canMove = newCanMove;
    }

    public bool CanPickUpItem(Vector3 pos)
    {
        GameTile currentTile = Manager.gameTileManager.gameTileMap[(int)pos.x, (int)pos.y];

        return currentTile.canBeHarvested;
    }

    public void HarvestCrop(Vector3 tilePos)
    {

        GameTile currentTile = Manager.gameTileManager.gameTileMap[(int)tilePos.x, (int)tilePos.y];
        Seed seedPlantedInTile = currentTile.plantedSeed;

        //Add item to inventory
        Manager.inventoryManager.AddItem(seedPlantedInTile.GetCropForHarvesting(), 1);

        //Reset the crop
        currentTile.ResetPlantedCrop();
    }

    public bool IsInRange(Vector3 clickedPos)
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

    private void LoadCharacterData()
    {
        SaveData loadedData = SaveSystem.LoadSaveData();
        characterProfile = loadedData._characterProfile;
    }

}
