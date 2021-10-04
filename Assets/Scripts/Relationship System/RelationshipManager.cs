using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelationshipManager : MonoBehaviour
{
    public List<NPCRelationship> npcRelationships;

    public List<RelationshipEvent> relationshipEvents = new List<RelationshipEvent>();

    public void AddExperienceToRelationship(NPC npc, int relationshipPoints)
    {
        for (int i = 0; i < npcRelationships.Count; i++)
        {
            if (npc.fullName == npcRelationships[i].npc.fullName)
            {
                npcRelationships[i].AddRelationshipExperience(relationshipPoints);
                print("Added experience to relationship");
            }
        }

        CheckRelationshipEvents(npc, relationshipPoints);
    }

    public void AddExperienceToRelationshipBasedOnItem(InventoryItem inventoryItem, NPC npc)
    {
        for (int i = 0; i < npcRelationships.Count; i++)
        {
            if (npcRelationships[i].npc.fullName == npc.fullName)
            {
                int relationshipExperienceAmount = npc.GetRelationshipExperienceAmountByItem(inventoryItem);
                AddExperienceToRelationship(npc, relationshipExperienceAmount);
            }
        }
    }

    public void CheckRelationshipEvents(NPC npc, int relationshipPoints)
    {
        for (int i = 0; i < relationshipEvents.Count; i++)
        {
            if (relationshipEvents[i].questEventBelongsTo.npcRelationship.npc.fullName == npc.fullName)
            {
                print("Relationship Event triggered");
                relationshipEvents[i].AddRelationshipPoints(relationshipPoints);
            }
        }
    }

    public void AddRelationshipEvents(RelationshipQuest quest)
    {
        relationshipEvents.Add(
            new RelationshipEvent
            {
                questEventBelongsTo = quest
            });
    }

    public void RemoveRelationshipEvents(RelationshipQuest quest)
    {
        for (int i = 0; i < relationshipEvents.Count; i++)
        {
            if (quest.ID == relationshipEvents[i].questEventBelongsTo.ID)
            {
                relationshipEvents.RemoveAt(i);
            }
        }
    }
}
