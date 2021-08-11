using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelationshipManager : MonoBehaviour
{

    public List<NPCRelationship> npcRelationships;

    public List<RelationshipEvent> relationshipEvents;

    public void AddExperienceToRelationship(NPC npc, int experienceAmount)
    {
        for (int i = 0; i < npcRelationships.Count; i++)
        {
            if (npc.fullName == npcRelationships[i].npc.fullName)
            {
                npcRelationships[i].AddRelationshipExperience(experienceAmount);
            }
        }
    }

    public void AddCollectionEvents(RelationshipQuest quest)
    {
        print(quest);
        relationshipEvents.Add(
            new RelationshipEvent
            {
                questEventBelongsTo = quest
            }
        );
    }

    public void RemoveCollectionEvents(CollectionQuest quest)
    {
        for (int i = 0; i < relationshipEvents.Count; i++)
        {
            if (quest.ID == relationshipEvents[i].questEventBelongsTo.ID)
            {
                relationshipEvents.RemoveAt(i);
            }
        }
    }

    public void GiveRelationshipQuestReward(RelationshipQuest relationshipQuest)
    {

    }
}
