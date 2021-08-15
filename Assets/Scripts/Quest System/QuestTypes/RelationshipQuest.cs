using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Relationship Quest", menuName = "Quest System/Quest/Relationship")]
public class RelationshipQuest : Quest
{
    public NPCRelationship npcRelationship;
    public int relationshipLevelGoal;


    public bool IsRelationshipGoalComplete()
    {
        return relationshipLevelGoal <= npcRelationship.relationshipLevel;
    }
}
