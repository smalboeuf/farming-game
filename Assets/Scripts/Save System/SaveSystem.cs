using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
    public static void SaveGameData(CharacterProfile characterProfile = null, float[] position = null)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/save.data";
        FileStream file = File.Create(path);

        if (characterProfile != null)
        {
            SaveData.current.SaveCharacterProfile(characterProfile);
        }

        if (position != null)
        {
            SaveData.current.SavePosition(position);
        }

        formatter.Serialize(file, SaveData.current);
        file.Close();
    }

    public static SaveData LoadSaveData()
    {
        string path = Application.persistentDataPath + "/save.data";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file = new FileStream(path, FileMode.Open);

            SaveData data = formatter.Deserialize(file) as SaveData;
            file.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
