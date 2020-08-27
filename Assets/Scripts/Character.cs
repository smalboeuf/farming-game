using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public float range = 10f;
    int speed = 5;
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
        
            if (IsInRange()) {
                if (hotbarManager.GetSelectedItem() is Tool tool) {
                    tool.UseTool();
                }
            }
          
        }
    }


    private bool IsInRange() {
        Vector3 clickedPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        if (Vector2.Distance(gameObject.transform.position, clickedPosition) <= range) {
            return true;
        } else {
            return false;
        }
    }

   
}
