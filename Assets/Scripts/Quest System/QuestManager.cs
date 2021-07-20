using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public List<Quest> activeQuests;
    public List<Quest> completedQuests;


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
    }

    public void CompleteQuest(Quest quest)
    {
        //Change scriptable object variables
        quest.isCompleted = true;
        quest.isActive = false;

        //Move to completed quest
        for (int i = 0; i < activeQuests.Count; i++)
        {
            if (activeQuests[i].ID == quest.ID)
            {
                activeQuests.RemoveAt(i);
            }
        }

        completedQuests.Add(quest);

        //Give rewards
        GiveQuestRewards(quest);
    }

    public void GiveQuestRewards(Quest quest)
    {
        //Update UI after all the things have been added
        
        //Add gold to players inventory
        Manager.inventoryManager.AddGold(quest.gold);
        //Add relationship points (need to create relationship system)
        
        //Add experience points (need to develop how experience and progression works)

        //Loop through all reward items and add it to the inventory
        for (int i = 0; i < quest.questRewards.Count; i++)
        {
            Manager.inventoryManager.AddItem(quest.questRewards[i].inventoryItem, quest.questRewards[i].amount);
        }
    }
}
