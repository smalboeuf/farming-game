using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class InventoryManager : MonoBehaviour
{

    [Header("Inventory Information")]
    [SerializeField] private GameObject inventoryPanel;
    public int gold = 0;

    public HotbarManager hotbarManager;

    [SerializeField] InventoryItem[] startingItems;
    public InventorySlot[] itemSlots;

    [SerializeField] InventoryItem testItem;


    [SerializeField] Image draggableItem;
    private InventorySlot draggedSlot;

    [SerializeField] ItemTooltip itemTooltip;

    //Events
    //public event Action<InventorySlot> OnPointerEnterEvent;
    //public event Action<InventorySlot> OnPointerExitEvent;
    //public event Action<InventorySlot> OnBeginDragEvent;
    //public event Action<InventorySlot> OnEndDragEvent;
    //public event Action<InventorySlot> OnDragEvent;
    //public event Action<InventorySlot> OnDropEvent;

    private void Awake()
    {
        SetStartingItems();
        InitializeHotbar();
    }


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < itemSlots.Length; i++) {
            itemSlots[i].OnPointerEnterEvent += ShowTooltip;
            itemSlots[i].OnPointerExitEvent += HideTooltip;
            itemSlots[i].OnBeginDragEvent += BeginDrag;
            itemSlots[i].OnEndDragEvent += EndDrag;
            itemSlots[i].OnDragEvent += Drag;
            itemSlots[i].OnDropEvent += Drop;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            AddItem(testItem, 7);
            Debug.Log("added item");
        }
    }

    //Inventory Drag Events
    public void ShowTooltip(InventorySlot inventorySlot)
    {
        itemTooltip.ShowTooltip(inventorySlot.Item);
    }

    public void HideTooltip(InventorySlot inventorySlot)
    {
        itemTooltip.HideTooltip();
    }

    private void BeginDrag(InventorySlot inventorySlot) {
        if (inventorySlot.Item != null) {
            draggedSlot = inventorySlot;
            draggableItem.sprite = inventorySlot.Item.itemImage;
            draggableItem.transform.position = Input.mousePosition;
            draggableItem.enabled = true;
        }
    }

    private void EndDrag(InventorySlot inventorySlot) {
        draggedSlot = null;
        draggableItem.enabled = false;
    }

    private void Drag(InventorySlot inventorySlot) {

        if (draggableItem.enabled) {
            draggableItem.transform.position = Input.mousePosition;
        }
    }

    private void Drop(InventorySlot dropInventorySlot) {

       if (dropInventorySlot.CanStackItem(draggedSlot.Item))
       {
            AddStacks(dropInventorySlot);
       }
       else if (dropInventorySlot.CanRecieveItem(dropInventorySlot.Item) && draggedSlot.CanRecieveItem(dropInventorySlot.Item))
       {
            SwapItems(dropInventorySlot);
       }

        hotbarManager.UpdateHotbarSlots();
    }

    private void SwapItems(InventorySlot dropInventorySlot)
    {
        InventoryItem draggedItem = draggedSlot.Item;
        int draggedItemAmount = draggedSlot.Amount;

        draggedSlot.Item = dropInventorySlot.Item;
        draggedSlot.Amount = dropInventorySlot.Amount;

        dropInventorySlot.Item = draggedItem;
        dropInventorySlot.Amount = draggedItemAmount;
    }

    private void AddStacks(InventorySlot dropInventorySlot)
    {
        int numbAddableStacks = dropInventorySlot.Item.maxStack - dropInventorySlot.Amount;
        int stacksToAdd = Mathf.Min(numbAddableStacks, draggedSlot.Amount);

        dropInventorySlot.Amount += stacksToAdd;
        draggedSlot.Amount -= stacksToAdd;
    }

    private void InitializeHotbar() {

        for (int i = 0; i < hotbarManager.hotbarSlots.Length; i++) {
            hotbarManager.hotbarSlots[i].SetHotbarSlot();
        }
        inventoryPanel.SetActive(false);
    }

    public void SetStartingItems() {
           
        int i = 0;

        for (; i < startingItems.Length && i < itemSlots.Length; i++) {
            itemSlots[i].Item = startingItems[i];
            itemSlots[i].Amount = 1;
        }

        for (; i < itemSlots.Length; i++) {
            itemSlots[i].Item = null;
            itemSlots[i].Amount = 0;
        }
    }

    public void AddGold(int goldAdded)
    {
        gold += goldAdded;
    }

    public bool AddItem(InventoryItem item, int quantity) {

        for (int i = 0; i < itemSlots.Length; i++) {
            if (itemSlots[i].CanStackItem(item)) {
                int sumOfItem = itemSlots[i].Amount + quantity;
                if (sumOfItem > itemSlots[i].Item.maxStack)
                {
                    itemSlots[i].Item = item;
                    itemSlots[i].Amount = item.maxStack;
                    hotbarManager.UpdateHotbarSlots();
                    int maxStackDifference = sumOfItem - itemSlots[i].Item.maxStack;
                    AddItem(item, maxStackDifference);
                }
                else {
                    itemSlots[i].Item = item;
                    itemSlots[i].Amount += quantity;
                }

                //Update hotbar after
                hotbarManager.UpdateHotbarSlots();
                return true;
            }
        }

        for (int i = 0; i < itemSlots.Length; i++) {
            if (itemSlots[i].Item == null) {

                itemSlots[i].Item = item;
                itemSlots[i].Amount = quantity;
                //Update hotbar after
                hotbarManager.UpdateHotbarSlots();
                return true;
            }
        }
      
        return false;
    }


    public bool RemoveItemAtHotbarIndex(int hotbarIndex, InventoryItem item) {

        if (itemSlots[hotbarIndex].Amount > 1)
        {
            itemSlots[hotbarIndex].Amount--;

            return true;
        }
        else if (itemSlots[hotbarIndex].Amount == 1)
        {

            itemSlots[hotbarIndex].Item = null;

            return true;
        }

        return false;
    }

    public bool RemoveItem(InventoryItem item)
    {

        for (int i = 0; i < itemSlots.Length; i++) {

            if (itemSlots[i].Item) {
                if (itemSlots[i].Item.ID == item.ID)
                {
                    if (itemSlots[i].Amount > 1)
                    {
                        itemSlots[i].Amount--;

                        return true;
                    }
                    else if (itemSlots[i].Amount == 1)
                    {

                        itemSlots[i].Item = null;

                        return true;
                    }

                }
            }
        
        }

        return false;
    }


    public bool isFull()
    {

        for (int i = 0; i < itemSlots.Length; i++) {

            if (itemSlots[i].Item == null) {
                return false;
            }
        }

        return true;

    }

}

