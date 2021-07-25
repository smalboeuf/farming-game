using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotbarManager : MonoBehaviour
{

    [Header("Inventory Information")]
    public PlayerInventory playerInventory;
   
    [SerializeField] private GameObject blankInventorySlot;
    [SerializeField] private GameObject hotbarPanel;


    [SerializeField] InventoryManager inventoryManager;
    public HotbarSlot[] hotbarSlots;


    public int selectedSlot = 0;


    private KeyCode[] keyCodes = {
         KeyCode.Alpha1,
         KeyCode.Alpha2,
         KeyCode.Alpha3,
         KeyCode.Alpha4,
         KeyCode.Alpha5,
         KeyCode.Alpha6,
         KeyCode.Alpha7,
         KeyCode.Alpha8,
    };


    public void GetHotbarPress()
    {

        for (int i = 0; i < keyCodes.Length; i++)
        {
            if (Input.GetKeyDown(keyCodes[i]))
            {
                UpdateHotbarSelection(i);
            }
        }
    }

    public void UpdateHotbarSelection(int hotbarIndex)
    {
        selectedSlot = hotbarIndex;

        UpdateHotBarSelectionUI(selectedSlot);
    }

    public void UpdateHotBarSelectionUI(int hotbarIndex)
    {
        ClearHotbarSelections();
        hotbarSlots[hotbarIndex].enableSelection();

    }

    public void ClearHotbarSelections() {

        for (int i = 0; i < hotbarSlots.Length; i++)
        {
            hotbarSlots[i].disableSelection();
        }
    }

    public InventoryItem GetSelectedItem() {
        return hotbarSlots[selectedSlot].itemSlot.Item;
    }

    public void UpdateHotbarSlots() {

        for (int i = 0; i < hotbarSlots.Length; i++) {
            hotbarSlots[i].SetHotbarSlot();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateHotbarSelection(0);
    }

    // Update is called once per frame
    void Update()
    {
        GetHotbarPress();
    }

    /*public bool IsAHoe() {


       if (playerHotbar.myHotbar[selectedSlot])
       {
           if (playerHotbar.myHotbar[selectedSlot].itemType == InventoryItem.ItemType.Hoe)
           {
               return true;
           }
           else
           {
               return false;
           }
       }
       else {
           return false;
       }

    }*/

    /*public bool IsSeeds() {

        if (playerHotbar.myHotbar[selectedSlot])
        {
            if (playerHotbar.myHotbar[selectedSlot].itemType == InventoryItem.ItemType.Seeds)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }*/

    /* public bool CanWaterSeeds() {

        if (playerHotbar.myHotbar[selectedSlot])
        {
            if (playerHotbar.myHotbar[selectedSlot].itemType == InventoryItem.ItemType.Bucket && playerHotbar.myHotbar[selectedSlot].itemName == "Water Bucket")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    } */






}
