using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Relationship Quest", menuName = "Quest System/Quest/Relationship")]
public class RelationshipQuest : Quest
{
    public NPC npc;
    public int relationshipHeartGoal;
}
