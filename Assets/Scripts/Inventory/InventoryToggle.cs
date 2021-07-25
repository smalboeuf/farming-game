using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryToggle : MonoBehaviour
{

    [SerializeField] GameObject inventory;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            inventory.SetActive(!inventory.activeSelf);

            if (inventory.activeSelf == true)
            {
                TurnOnInventoryPanel();
            }
            else {
                TurnOffInventoryPanel();
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {
            inventory.SetActive(false);
            TurnOffInventoryPanel();
        }
        
    }

    public void TurnOffInventoryPanel() {
        Manager.inventoryManager.HideTooltip(null);
        Manager.character.SetCanMove(true);
    }   

    public void TurnOnInventoryPanel() {
        Manager.character.SetCanMove(false);
    }
}
