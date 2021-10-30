using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearanceChanger : MonoBehaviour
{
    public SpriteRenderer customizablePart;

    public List<Sprite> options = new List<Sprite>();

    private int currentOption = 0;

    public void NextOption()
    {
        currentOption++;
        if (currentOption >= options.Count)
        {
            currentOption = 0;
        }

        customizablePart.sprite = options[currentOption];
    }

    public void PreviousOption()
    {
        currentOption--;

        if (currentOption < 0)
        {
            currentOption = options.Count - 1;
        }

        customizablePart.sprite = options[currentOption];
    }
}
