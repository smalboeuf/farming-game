using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveAppearanceButton : MonoBehaviour
{
    public void SaveCharacterAppearance(CharacterProfile characterProfile)
    {
        SaveSystem.SaveGameData(characterProfile);
    }
}
