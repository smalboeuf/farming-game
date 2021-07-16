﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "New Quest", menuName = "Quest System/Quest")]
[System.Serializable]
public class Quest : ScriptableObject
{
    //Quest Specs
    [SerializeField] string id;
    public string ID { get { return id; } }
    public string QuestName;
    public string QuestDescription;
    public bool isActive;
    public bool isCompleted = false;
    public QuestType questType;
    

    //Quest Rewards
    public int experiencePoints;
    public int gold;
    public int relationshipPoints;
    public InventoryItem inventoryItem;

    //Need to have
    // Prerequisite quests
    public Quest prerequisiteQuest;
    // Next quest if there is any
    public Quest nextQuest;
    
  
    public enum QuestType {
        Collect = 0,
        Exploration = 1,
        Relationship = 2
    }

    private void OnValidate()
    {
        string path = AssetDatabase.GetAssetPath(this);
        id = AssetDatabase.AssetPathToGUID(path);
    }

    private QuestType GetQuestType()
    {
        return questType;
    }

    public void QuestResult()
    { 
    }
}
