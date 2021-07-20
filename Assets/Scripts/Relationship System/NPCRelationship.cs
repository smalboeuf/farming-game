using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCRelationship : ScriptableObject
{
    public NPC npc;
    public int relationshipLevel;
    public int maxRelationshipLevel;

    public int currentRelationshipExp;
    public int maxRelationshipExp;

    public int levelUpMultiplierPercentage = 5;


    public void AddRelationshipExperience(int amount)
    {
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
        relationshipLevel++;
        currentRelationshipExp = excessExp;

        //Change the size of next level required exp
        maxRelationshipExp *= (1 + (levelUpMultiplierPercentage / 100));

        //Update any UI elements
    }

    public void RelationshipExpDecay()
    {

    }
}
