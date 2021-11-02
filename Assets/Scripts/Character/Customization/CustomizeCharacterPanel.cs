using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CustomizeCharacterPanel : MonoBehaviour
{
    [SerializeField] private ColorCustomizer hairColor;
    [SerializeField] private ColorCustomizer eyeColor;
    [SerializeField] private AppearanceChanger hair;
    [SerializeField] private AppearanceChanger shirt;
    [SerializeField] private AppearanceChanger pants;
    [SerializeField] private AppearanceChanger boots;
    [SerializeField] private AppearanceChanger skin;
    [SerializeField] private TMP_InputField nameInput;

    public void SaveCharacterAppearance()
    {
        CharacterProfile characterProfile = new CharacterProfile()
        {
            name = nameInput.text,
            hairOption = hair.GetCurrentOption(),
            hairColor = new ColorSaveModel(hairColor.GetColor().r, hairColor.GetColor().g, hairColor.GetColor().b, hairColor.GetColor().a),
            eyeColor = new ColorSaveModel(eyeColor.GetColor().r, eyeColor.GetColor().g, eyeColor.GetColor().b, eyeColor.GetColor().a),
            shirtOption = shirt.GetCurrentOption(),
            pantsOption = pants.GetCurrentOption(),
            bootsOption = boots.GetCurrentOption(),
            skinOption = skin.GetCurrentOption()
        };

        SaveSystem.SaveGameData(characterProfile);
    }
}
