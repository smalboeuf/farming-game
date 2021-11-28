using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CustomizeCharacterPanel : MonoBehaviour
{
    [SerializeField] private ColorCustomizer hairColor;
    [SerializeField] private ColorCustomizer eyeColor;
    [SerializeField] private AppearanceChanger hair;
    [SerializeField] private AppearanceChanger eyes;
    [SerializeField] private AppearanceChanger shirt;
    [SerializeField] private AppearanceChanger pants;
    [SerializeField] private AppearanceChanger boots;
    [SerializeField] private AppearanceChanger skin;
    [SerializeField] private TMP_InputField nameInput;

    [SerializeField] private PlayerModel playerModel;

    public void SaveCharacterAppearance()
    {
        CharacterProfile characterProfile = new CharacterProfile()
        {
            name = nameInput.text,
            hairOption = hair.GetCurrentOption(),
            hairColor = new ColorSaveModel(hairColor.color.r, hairColor.color.g, hairColor.color.b, hairColor.color.a),
            eyeColor = new ColorSaveModel(eyeColor.color.r, eyeColor.color.g, eyeColor.color.b, eyeColor.color.a),
            eyeOption = eyes.GetCurrentOption(),
            shirtOption = shirt.GetCurrentOption(),
            handsOption = skin.GetCurrentOption(),
            pantsOption = pants.GetCurrentOption(),
            bootsOption = boots.GetCurrentOption(),
            skinOption = skin.GetCurrentOption()
        };

        SaveSystem.SaveGameData(characterProfile);
    }

    public void HandleAppearanceConfirmation()
    {
        SaveCharacterAppearance();
        playerModel.SetPlayerModel();
        gameObject.SetActive(false);
    }
}
