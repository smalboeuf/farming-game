using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorCustomizer : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private Slider hueSlider;
    [SerializeField] private Slider saturationSlider;
    [SerializeField] private Slider valueSlider;

    private void Start()
    {
        image.color = Color.HSVToRGB(hueSlider.value, saturationSlider.value, valueSlider.value);
    }

    public void OnEdit()
    {
        image.color = Color.HSVToRGB(hueSlider.value, saturationSlider.value, valueSlider.value);
    }
}
