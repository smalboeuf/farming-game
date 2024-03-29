﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [Header("Quest Manager Data")]
    public List<Quest> activeQuests;
    public List<Quest> questsToBeHandedIn;
    public List<Quest> completedQuests;

    [Header("UI GameObjects")]
    [SerializeField] private GameObject questPanel;
    [SerializeField] private GameObject questPanelContent;
    [SerializeField] private GameObject questUIPrefab;
    public QuestDescriptionPanel questDescriptionPanel;

    private void Start()
    {
        InitializeQuestPanel();
    }

    public void ToggleQuestPanel()
    {
        questPanel.gameObject.SetActive(!questPanel.gameObject.activeSelf);
        questDescriptionPanel.gameObject.SetActive(false);
        if (questPanel.gameObject.activeSelf == true)
        {
            Manager.character.SetCanMove(false);
        }
        else
        {
            Manager.character.SetCanMove(true);
        }
    }

    private void InitializeQuestPanel()
    {
        for (int i = 0; i < activeQuests.Count; i++)
        {
            CreateQuestUI(activeQuests[i]);
        }
    }

    private void RemoveQuestUI(Quest quest)
    {
        foreach (Transform child in questPanelContent.transform)
        {
            QuestUI questTransformUI = child.GetComponent<QuestUI>();

            if (questTransformUI.quest.ID == quest.ID)
            {
                Destroy(child.gameObject);
            }
        }
    }

    private void CreateQuestUI(Quest quest)
    {
        var newQuestGameObject = Instantiate(questUIPrefab, questPanelContent.transform);
        var newQuest = newQuestGameObject.GetComponent<QuestUI>();
        newQuest.SetQuestUIElements(quest);
    }

    // Check to see if a quest is active
    public bool isActive(Quest quest)
    {
        for (int i = 0; i < activeQuests.Count; i++)
        {
            if (activeQuests[i].ID == quest.ID)
            {
                return true;
            }
        }

        return false;
    }

    // Accept a quest
    public void AcceptQuest(Quest quest)
    {
        //Set quest to active and in active list
        quest.isActive = true;
        activeQuests.Add(quest);
        CreateQuestUI(quest);

        //Add on collect events whenever quest is accepted
        if (quest.IsCollectionQuest())
        {
            Manager.inventoryManager.AddCollectionEvents((CollectionQuest)quest);
        }

        if (quest.IsRelationshipQuest())
        {
            Manager.relationshipManager.AddRelationshipEvents((RelationshipQuest)quest);
        }

        if (quest.IsExplorationQuest())
        {
            // Create exploration point on the map
            Manager.explorationManager.InstantiateExplorationPoint((ExplorationQuest)quest);
            // Add exploration event
            Manager.explorationManager.AddExplorationEvents((ExplorationQuest)quest);
        }
    }

    public void FulfillQuestNeeds(Quest quest)
    {
        for (int i = 0; i < activeQuests.Count; i++)
        {
            if (activeQuests[i].ID == quest.ID)
            {
                // Quest is ready to be handed in
                questsToBeHandedIn.Add(quest);
            }
        }
    }

    public void CompleteQuest(Quest quest)
    {
        print("Complete quest" + quest);
        // Change scriptable object variables
        quest.isCompleted = true;
        quest.isActive = false;

        // Move to completed quest
        for (int i = 0; i < activeQuests.Count; i++)
        {
            if (activeQuests[i].ID == quest.ID)
            {
                activeQuests.RemoveAt(i);
            }
        }

        for (int i = 0; i < questsToBeHandedIn.Count; i++)
        {
            if (questsToBeHandedIn[i].ID == quest.ID)
            {
                questsToBeHandedIn.RemoveAt(i);
            }
        }

        completedQuests.Add(quest);

        // Give rewards
        GiveQuestRewards(quest);

        RemoveQuestUI(quest);
    }

    public void GiveQuestRewards(Quest quest)
    {
        //Update UI after all the things have been added

        //Add gold to players inventory
        Manager.inventoryManager.AddGold(quest.gold);
        //Add relationship points (need to create relationship system)
        Manager.relationshipManager.AddExperienceToRelationship(quest.questGiver, quest.relationshipPointsGained);
        //Add skill experience
        Manager.skillsManager.AddExperienceToSkill(quest.skillType, quest.skillExperience);

        //Loop through all reward items and add it to the inventory
        for (int i = 0; i < quest.questRewards.Count; i++)
        {
            Manager.inventoryManager.AddItem(quest.questRewards[i].inventoryItem, quest.questRewards[i].amount);
        }
    }

    public Quest HasQuestToHandIn(NPC npc)
    {
        for (int i = 0; i < questsToBeHandedIn.Count; i++)
        {
            if (questsToBeHandedIn[i].questGiver.fullName == npc.fullName)
            {
                return questsToBeHandedIn[i];
            }
        }

        return null;
    }

    public void CheckIfGiftCompletesQuest(InventoryItem inventoryItem, NPC npc)
    {
        for (int i = 0; i < activeQuests.Count; i++)
        {
            if (activeQuests[i].questGiver.fullName == npc.fullName)
            {
                if (activeQuests[i].IsCollectionQuest())
                {
                    CollectionQuest collectionQuest = (CollectionQuest)activeQuests[i];
                    // Complete quest
                    for (int y = 0; i < collectionQuest.itemDemands.Count; i++)
                    {
                        print("got here");
                        if (collectionQuest.itemDemands[y].item.ID == inventoryItem.ID)
                        {
                            collectionQuest.HandInItem(inventoryItem);

                            if (collectionQuest.isItemsCollected())
                            {
                                // Complete the quest with the NPC
                                print("Handed in item to NPC and completed quest");
                                CompleteQuest(collectionQuest);

                                // @TODO: TRIGGER SOME DIALOGUE FROM THE NPC TO THANK THE PLAYER FOR COMPLETING A QUEST
                            }
                        }
                    }
                }
            }
        }
    }
}

//Take in the item, check if a quest asks for this item