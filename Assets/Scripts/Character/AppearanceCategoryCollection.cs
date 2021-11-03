using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Character/Appearance Category Collection")]
public class AppearanceCategoryCollection : ScriptableObject
{
    [SerializeField] private string collectionName;
    [SerializeField] private List<AppearanceOption> collectionOptions;

    public string GetCollectionName()
    {
        return collectionName;
    }

    public Sprite GetCollectionOption(int optionChoice)
    {
        return collectionOptions[optionChoice].GetOptionSprite();
    }

    public int GetCollectionSize()
    {
        return collectionOptions.Count;
    }
}