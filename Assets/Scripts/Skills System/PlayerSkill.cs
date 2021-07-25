using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : ScriptableObject
{
    public string Name { get; set; }
    public SkillType skillType { get; set; }

    //Skill leveling stats
    public int currentSkillExp;
    public int maxSkillExp;
    public int skillLevel;
    public int maxSkillLevel;

    public int levelUpMultiplierPercentage = 5;


    public void AddSkillExperience(int amount)
    {
        if (skillLevel == maxSkillLevel)
        {
            return;
        }

        int newCurrentSkillExp = currentSkillExp + amount;

        if (newCurrentSkillExp >= maxSkillExp)
        {
            int excessExp = newCurrentSkillExp - maxSkillExp;

        }
    }

    public void LevelUpSkill(int excessExp)
    {
        if (skillLevel < maxSkillLevel)
        {
            skillLevel++;

            if (skillLevel == maxSkillLevel)
            {
                currentSkillExp = 0;
                return;
            }
            else
            {
                currentSkillExp = excessExp;
            }
        }
        else {
            return;
        }

        //Change the size of the next level required exp
        maxSkillExp *= (1 + (levelUpMultiplierPercentage / 100));
    }
}
