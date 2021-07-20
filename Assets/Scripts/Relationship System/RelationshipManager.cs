using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelationshipManager : MonoBehaviour
{

    public List<NPCRelationship> npcRelationships;

    public void AddRelationshipExperience(NPC npc, int experienceAmount)
    {
        for (int i = 0; i < npcRelationships.Count; i++)
        {
            if (npc.fullName == npcRelationships[i].npc.fullName)
            {
                npcRelationships[i].AddRelationshipExperience(experienceAmount);
            }
        }
    }
}
