using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AppearanceChanger : MonoBehaviour
{
    public Image customizablePart;
    [SerializeField] private string optionTextPrefix = "";
    [SerializeField] private TextMeshProUGUI optionText;
    [SerializeField] private AppearanceCategoryCollection collectionOptions;

    private int m_currentOption = 0;

    public int currentOption => m_currentOption;

    private void Start()
    {
        customizablePart.sprite = collectionOptions.GetCollectionOption(currentOption);
        optionText.text = GetOptionText(currentOption);
    }

    public int GetCurrentOption()
    {
        return currentOption;
    }

    public void NextOption()
    {
        m_currentOption++;
        if (currentOption >= collectionOptions.GetCollectionSize())
        {
            m_currentOption = 0;
        }

        customizablePart.sprite = collectionOptions.GetCollectionOption(currentOption);
        optionText.text = GetOptionText(currentOption);
    }

    public void PreviousOption()
    {
        m_currentOption--;

        if (currentOption < 0)
        {
            m_currentOption = collectionOptions.GetCollectionSize() - 1;
        }

        customizablePart.sprite = collectionOptions.GetCollectionOption(currentOption);
        optionText.text = GetOptionText(currentOption);
    }

    public string GetOptionText(int optionNumber)
    {
        return $"{optionTextPrefix} #{optionNumber + 1}";
    }
}
