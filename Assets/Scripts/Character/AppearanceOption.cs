using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Character/Appearance Option")]
public class AppearanceOption : ScriptableObject
{
    [SerializeField] private Sprite optionSprite;
    [SerializeField] private RuntimeAnimatorController animatorController;

    public Sprite GetOptionSprite()
    {
        return optionSprite;
    }

    public RuntimeAnimatorController GetAnimatorController()
    {
        return animatorController;
    }
}
