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
        //Manager.inventoryManager.AddItem();
    }
}
