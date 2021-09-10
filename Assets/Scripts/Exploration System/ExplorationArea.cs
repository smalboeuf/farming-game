using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Exploration Area", menuName = "Exploration/New Exploration Area")]
public class ExplorationArea : ScriptableObject
{
    [SerializeField]
    public string areaName;

    // Location
    public float x;
    public float y;

    [SerializeField]
    private bool explored = false;

    public void SetExplored(bool isExplored)
    {
        explored = isExplored;
    }
}
