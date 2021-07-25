using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillsManager : MonoBehaviour
{

    public List<PlayerSkill> playerSkills;

    public void AddExperienceToSkill(SkillType skillType, int experienceAmount)
    {
        for (int i = 0; i < playerSkills.Count; i++)
        {
            if (playerSkills[i].skillType == skillType)
            {
                playerSkills[i].AddSkillExperience(experienceAmount);
            }
        }
    }
}
