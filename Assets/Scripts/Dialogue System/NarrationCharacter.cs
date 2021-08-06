using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Narration/Dialogue/NarrationCharacter")]
public class NarrationCharacter : ScriptableObject
{
    [SerializeField] private string m_CharacterName;
    [SerializeField] private Sprite m_CharacterSprite;

    public string CharacterName => m_CharacterName;
    public Sprite CharacterSprite => m_CharacterSprite;
}
