using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    public List<Quest> questsToGive;
    public List<Quest> questsGiven;


    public void DeliverQuest(Quest quest)
    {
        Manager.questManager.AcceptQuest(quest);

        for (int i = 0; i < questsToGive.Count; i++)
        {
            if (questsToGive[i].ID == quest.ID)
            {
                questsToGive.RemoveAt(i);
                questsGiven.Add(quest);
                return;
            }
        }
    }

    //When you interact with a QuestGiver call this
    public List<Quest> GetAvailableQuests() {

        List<Quest> availableQuests = new List<Quest>();

        foreach (Quest quest in questsToGive)
        {
            if (quest.prerequisiteQuest == null)
            {
                availableQuests.Add(quest);
                continue;
            }
            else {

                for (int i = 0; i < Manager.questManager.completedQuests.Count; i++)
                {
                    if (quest.ID == Manager.questManager.completedQuests[i].ID)
                    {
                        //Add quest to available quests
                        availableQuests.Add(quest);
                    }
                }
                    
            }
        }

        return availableQuests;
    }
}
