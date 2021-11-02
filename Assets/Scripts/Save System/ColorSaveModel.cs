using System;
using UnityEngine;

[Serializable]
public class ColorSaveModel
{
    public float _r;
    public float _g;
    public float _b;
    public float _a;

    public ColorSaveModel(float r, float g, float b, float a)
    {
        _r = r;
        _g = g;
        _b = b;
        _a = a;
    }
}
