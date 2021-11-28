using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Character/Appearance Option")]
public class AppearanceOption : ScriptableObject
{
    [SerializeField] private Sprite m_optionSprite;
    [SerializeField] private RuntimeAnimatorController m_animatorController;

    public Sprite optionSprite => m_optionSprite;
    public RuntimeAnimatorController animatorController => m_animatorController;
}
