using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float range = 10f;
    int speed = 5;
    int maxHP = 100;
    int currentHP = 90;
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
        if (Input.GetMouseButtonDown(0)) {
            Vector3 clickedPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (hotbarManager.GetSelectedItem() is Tool tool) {

                if (IsInRange(clickedPosition) && IsAValidCoordinate((int)clickedPosition.x, (int)clickedPosition.y))
                {
                   tool.UseTool((int)clickedPosition.x, (int)clickedPosition.y);
                }
            }
          
        }
        if (Input.GetMouseButtonDown(1)) {
            if (hotbarManager.GetSelectedItem() is Consumable consumable) {
                consumable.UseConsumable(hotbarManager.selectedSlot, consumable);
            }
        }
    }


    private bool IsInRange(Vector3 clickedPos) {

        if (Vector2.Distance(gameObject.transform.position, clickedPos) <= range) {
            return true;
        } else {
            return false;
        }
    }


    public void Heal(int amount) {

        if (amount + currentHP > maxHP)
        {
            currentHP = maxHP;
        }
        else {
            currentHP = currentHP + amount;
        }

    }

    public bool IsAValidCoordinate(int xPos, int yPos) {
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
