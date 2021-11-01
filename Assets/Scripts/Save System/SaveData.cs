using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    private static SaveData _current;

    public static SaveData current
    {
        get
        {
            if (_current == null)
            {
                _current = new SaveData();
            }

            return _current;
        }
    }

    public void SaveCharacterProfile(CharacterProfile characterProfile)
    {
        _current._characterProfile = characterProfile;
    }

    public void SavePosition(float[] position)
    {
        _current._position = position;
    }

    // Character visual details
    public CharacterProfile _characterProfile;

    // Character position
    public float[] _position;

    // Character inventory
}
