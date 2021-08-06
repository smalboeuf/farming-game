using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue_OLD
{
    public string name;
    public Quest questOffered;

    [TextArea(3, 10)]
    public string[] sentences;
}
