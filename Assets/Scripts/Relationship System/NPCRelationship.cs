using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New NPC Relationship", menuName = "Relationships/NPC Relationship")]
[System.Serializable]
public class NPCRelationship : ScriptableObject
{
    public NPC npc;
    public int relationshipLevel;
    public int maxRelationshipLevel = 10;

    public int currentRelationshipExp;
    public int maxRelationshipExp;

    public int levelUpMultiplierPercentage = 5;

    public void AddRelationshipExperience(int amount)
    {
        if (relationshipLevel == maxRelationshipLevel)
        {
            return;
        }

        int newCurrentRelationshipExp = currentRelationshipExp + amount;

        if (newCurrentRelationshipExp >= maxRelationshipExp)
        {
            int excessExp = newCurrentRelationshipExp - maxRelationshipExp;
            LevelUpRelationship(excessExp);
        }
    }

    public void LevelUpRelationship(int excessExp)
    {
        //Increase relationship level
        if (relationshipLevel < maxRelationshipLevel)
        {
            relationshipLevel++;

            if (relationshipLevel == maxRelationshipLevel)
            {
                currentRelationshipExp = 0;
                return;
            }
            else
            {
                currentRelationshipExp = excessExp;
            }
        }
        else
        {
            return;
        }
    
        //Change the size of next level required exp
        maxRelationshipExp *= (1 + (levelUpMultiplierPercentage / 100));

        //Update any UI elements
    }

    public void RelationshipExpDecay()
    {
        //Handle relationship decay over x period of time
    }
}
