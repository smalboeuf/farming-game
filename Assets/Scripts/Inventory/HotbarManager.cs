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

    private int m_selectedSlot = 0;

    public int selectedSlot => m_selectedSlot;

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

    public void UpdateHotbarPress()
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
        m_selectedSlot = hotbarIndex;

        UpdateHotBarSelectionUI(m_selectedSlot);
    }

    public void UpdateHotBarSelectionUI(int hotbarIndex)
    {
        ClearHotbarSelections();
        hotbarSlots[hotbarIndex].enableSelection();

    }

    public void ClearHotbarSelections()
    {

        for (int i = 0; i < hotbarSlots.Length; i++)
        {
            hotbarSlots[i].disableSelection();
        }
    }

    public InventoryItem GetSelectedItem()
    {
        return hotbarSlots[m_selectedSlot].itemSlot.Item;
    }

    public void UpdateHotbarSlots()
    {

        for (int i = 0; i < hotbarSlots.Length; i++)
        {
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
        UpdateHotbarPress();
    }
}
