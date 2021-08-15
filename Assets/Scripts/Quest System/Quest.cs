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

    [Header("Quest Rewards")]

    //Skills reward
    public SkillType skillType;
    public int skillExperience = 0;
    
    //Gold rewards
    public int gold = 0;

    //Relationship reward
    public NPC questGiver;
    public int relationshipPointsGained = 0;

    //Item rewards
    public List<QuestReward> questRewards = new List<QuestReward>();

    [Header("Quest order information")]
    //Prerequisite quests
    public Quest prerequisiteQuest;
    //Next quest if there is any
    public Quest nextQuest;
    
    public enum QuestType {
        Collection,
        Exploration,
        Relationship
    }

    private void OnValidate()
    {
        string path = AssetDatabase.GetAssetPath(this);
        id = AssetDatabase.AssetPathToGUID(path);
    }

    public QuestType GetQuestType()
    {
        return questType;
    }

    public bool IsCollectionQuest()
    {
        return questType == QuestType.Collection;
    }

    public bool IsRelationshipQuest()
    {
        return questType == QuestType.Relationship;
    }

    public bool IsExplorationQuest()
    {
        return questType == QuestType.Exploration;
    }

    public void QuestResult()
    { 
    }
}
