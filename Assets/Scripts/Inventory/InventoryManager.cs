﻿using System.Collections;
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

    [SerializeField] InventoryItem[] startingItems;
    public InventorySlot[] itemSlots;

    [SerializeField] InventoryItem testItem;

    [SerializeField] Image draggableItem;
    private InventorySlot draggedSlot;

    [SerializeField] ItemTooltip itemTooltip;

    [SerializeField] List<CollectionEvent> collectionEvents = new List<CollectionEvent>();

    [SerializeField] GameObject itemPickupPrefab;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            itemSlots[i].OnPointerEnterEvent += ShowTooltip;
            itemSlots[i].OnPointerExitEvent += HideTooltip;
            itemSlots[i].OnPointClickEvent += HandlePointerClick;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            AddItem(testItem, 7);
            Debug.Log("added item");
        }

        if (draggableItem.enabled)
        {
            draggableItem.transform.position = Input.mousePosition;
        }
    }

    public GameObject GetItemPickupPrefab()
    {
        return itemPickupPrefab;
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

    public void PlayerDropItem()
    {
        if (draggedSlot != null)
        {
            print("Dropping item");
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            GameObject itemPickupGameObject = itemPickupPrefab;
            ItemPickup newItemPickup = itemPickupGameObject.GetComponent<ItemPickup>();
            newItemPickup.SetItem(draggedSlot.Item);
            newItemPickup.SetStackQuantity(draggedSlot.Amount);
            newItemPickup.SetImage();
            newItemPickup.SetWasDropped(true);
            var itemPickup = Instantiate(itemPickupGameObject, new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z), Quaternion.identity);
            draggedSlot.Item = null;
            draggedSlot.Amount = 0;
            ClearDraggedItem();
            Manager.hotbarManager.UpdateHotbarSlots();
        }
    }

    private void HandlePointerClick(InventorySlot inventorySlot)
    {
        if (inventorySlot.Item != null)
        {
            if (draggedSlot != null)
            {
                Drop(inventorySlot);
            }
            else
            {
                draggedSlot = inventorySlot;
                draggableItem.sprite = inventorySlot.Item.itemImage;
                draggableItem.transform.position = Input.mousePosition;
                draggableItem.enabled = true;
            }
        }
        else
        {
            if (draggedSlot != null)
            {
                Drop(inventorySlot);
                draggedSlot = null;
                draggableItem.enabled = false;
            }
        }
    }

    private void Drop(InventorySlot dropInventorySlot)
    {
        if (dropInventorySlot.CanStackItem(draggedSlot.Item))
        {
            AddStacks(dropInventorySlot);
        }
        else if (dropInventorySlot.CanRecieveItem(dropInventorySlot.Item) && draggedSlot.CanRecieveItem(dropInventorySlot.Item))
        {
            SwapItems(dropInventorySlot);
        }

        Manager.hotbarManager.UpdateHotbarSlots();
    }

    private void BeginDrag(InventorySlot inventorySlot)
    {
        if (inventorySlot.Item != null)
        {
            draggedSlot = inventorySlot;
            draggableItem.sprite = inventorySlot.Item.itemImage;
            draggableItem.transform.position = Input.mousePosition;
            draggableItem.enabled = true;
        }
    }

    private void EndDrag(InventorySlot inventorySlot)
    {
        draggedSlot = null;
        draggableItem.enabled = false;
    }

    private void Drag(InventorySlot inventorySlot)
    {
        if (draggableItem.enabled)
        {
            draggableItem.transform.position = Input.mousePosition;
        }
    }
    private void SwapItems(InventorySlot dropInventorySlot)
    {
        InventoryItem draggedItem = draggedSlot.Item;
        int draggedItemAmount = draggedSlot.Amount;

        draggedSlot.Item = dropInventorySlot.Item;
        draggedSlot.Amount = dropInventorySlot.Amount;

        dropInventorySlot.Item = draggedItem;
        dropInventorySlot.Amount = draggedItemAmount;

        ClearDraggedItem();
    }

    private void ClearDraggedItem()
    {
        draggedSlot = null;
        draggableItem.enabled = false;
    }

    private void AddStacks(InventorySlot dropInventorySlot)
    {
        int numbAddableStacks = dropInventorySlot.Item.maxStack - dropInventorySlot.Amount;
        int stacksToAdd = Mathf.Min(numbAddableStacks, draggedSlot.Amount);

        dropInventorySlot.Amount += stacksToAdd;
        draggedSlot.Amount -= stacksToAdd;

        ClearDraggedItem();
    }

    public void InitializeHotbar()
    {

        for (int i = 0; i < Manager.hotbarManager.hotbarSlots.Length; i++)
        {
            Manager.hotbarManager.hotbarSlots[i].SetHotbarSlot();
        }
        inventoryPanel.SetActive(false);
    }

    public void SetStartingItems()
    {

        int i = 0;

        for (; i < startingItems.Length && i < itemSlots.Length; i++)
        {
            itemSlots[i].Item = startingItems[i];
            itemSlots[i].Amount = 1;
        }

        for (; i < itemSlots.Length; i++)
        {
            itemSlots[i].Item = null;
            itemSlots[i].Amount = 0;
        }
    }

    public void AddGold(int goldAdded)
    {
        gold += goldAdded;
    }

    public bool AddItem(InventoryItem item, int quantity)
    {

        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].CanStackItem(item))
            {
                int sumOfItem = itemSlots[i].Amount + quantity;
                if (sumOfItem > itemSlots[i].Item.maxStack)
                {
                    itemSlots[i].Item = item;
                    itemSlots[i].Amount = item.maxStack;
                    Manager.hotbarManager.UpdateHotbarSlots();
                    int maxStackDifference = sumOfItem - itemSlots[i].Item.maxStack;
                    //Recursion
                    AddItem(item, maxStackDifference);
                }
                else
                {
                    itemSlots[i].Item = item;
                    itemSlots[i].Amount += quantity;
                }

                //Update hotbar after
                Manager.hotbarManager.UpdateHotbarSlots();

                //Check for collection events
                CheckCollectionEvents(item, quantity);

                return true;
            }
        }

        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].Item == null)
            {

                itemSlots[i].Item = item;
                itemSlots[i].Amount = quantity;
                //Update hotbar after
                Manager.hotbarManager.UpdateHotbarSlots();
                //Check for collection events
                CheckCollectionEvents(item, quantity);

                return true;
            }
        }

        return false;
    }

    public void CheckCollectionEvents(InventoryItem item, int amount)
    {
        for (int i = 0; i < collectionEvents.Count; i++)
        {
            if (collectionEvents[i].itemCollectionDemand.item.ID == item.ID)
            {
                collectionEvents[i].CollectDemandItem(item, amount);
            }
        }
    }

    public void AddCollectionEvents(CollectionQuest quest)
    {
        foreach (ItemCollectionDemand itemDemand in quest.itemDemands)
        {
            collectionEvents.Add(
                new CollectionEvent
                {
                    itemCollectionDemand = itemDemand,
                    questEventBelongsTo = quest
                }
            );
        }
    }

    public void RemoveCollectionEvents(CollectionQuest quest)
    {
        for (int i = 0; i < collectionEvents.Count; i++)
        {
            if (quest.ID == collectionEvents[i].questEventBelongsTo.ID)
            {
                collectionEvents.RemoveAt(i);
            }
        }
    }

    public int GetItemAmountInInventory(InventoryItem item)
    {
        int totalAmount = 0;

        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].Item.ID == item.ID)
            {
                totalAmount += itemSlots[i].Amount;
            }
        }

        return totalAmount;
    }

    public bool RemoveItemAtHotbarIndex(int hotbarIndex, InventoryItem item)
    {
        if (itemSlots[hotbarIndex].Amount > 1)
        {
            itemSlots[hotbarIndex].Amount--;
            Manager.hotbarManager.UpdateHotbarSlots();
            return true;
        }
        else if (itemSlots[hotbarIndex].Amount == 1)
        {

            itemSlots[hotbarIndex].Item = null;
            Manager.hotbarManager.UpdateHotbarSlots();
            return true;
        }

        return false;
    }

    public bool RemoveItem(InventoryItem item, int quantity)
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {

            if (itemSlots[i].Item)
            {
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

        for (int i = 0; i < itemSlots.Length; i++)
        {

            if (itemSlots[i].Item == null)
            {
                return false;
            }
        }

        return true;
    }
}

