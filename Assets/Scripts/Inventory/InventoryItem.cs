﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEditor;


[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Items")]
public class InventoryItem : ScriptableObject
{
    [SerializeField] string id;
    public string ID { get { return id; } }
    public string itemName;
    public string itemDescription;
    public Sprite itemImage;
    public int currentStack;
    public int maxStack;
    public int sellPrice;
    public int buyPrice;
    //public bool usable;
    public bool unique;
    public ItemType itemType;


    public enum ItemType
    {
        Sword,
        Hoe,
        Seeds,
        Creature,
        Tool,
        Food,
        Weapon
    };

    


    private void OnValidate()
    {
        string path = AssetDatabase.GetAssetPath(this);
        id = AssetDatabase.AssetPathToGUID(path);
    }


    public ItemType GetItemType() {
        return itemType;
    }


 

}
