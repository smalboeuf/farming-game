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

    public List<Sprite> options = new List<Sprite>();

    private int currentOption = 0;

    private void Start()
    {
        customizablePart.sprite = options[currentOption];
        optionText.text = GetOptionText(currentOption);
    }

    public void NextOption()
    {
        currentOption++;
        if (currentOption >= options.Count)
        {
            currentOption = 0;
        }

        customizablePart.sprite = options[currentOption];
        optionText.text = GetOptionText(currentOption);
    }

    public void PreviousOption()
    {
        currentOption--;

        if (currentOption < 0)
        {
            currentOption = options.Count - 1;
        }

        customizablePart.sprite = options[currentOption];
        optionText.text = GetOptionText(currentOption);
    }

    public string GetOptionText(int optionNumber)
    {
        return $"{optionTextPrefix} #{optionNumber + 1}";
    }
}
