using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelationshipEvent
{
    public RelationshipQuest questEventBelongsTo;

    public void AddRelationshipPoints(int relationshipPoints)
    {
        questEventBelongsTo.npcRelationship.AddRelationshipExperience(relationshipPoints);

        if (questEventBelongsTo.IsRelationshipGoalComplete())
        {
            // Complete relationship quest
            Manager.questManager.CompleteQuest(questEventBelongsTo);
            Manager.relationshipManager.RemoveRelationshipEvents(questEventBelongsTo);
        }
    }
}
