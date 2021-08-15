using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ExplorationEvent
{
    public ExplorationArea explorationArea;
    public ExplorationQuest questEventBelongsTo;


    public void ExploreExplorationArea()
    {
        //Finish this  based on other event structure
        Manager.questManager.CompleteQuest(questEventBelongsTo);
        Manager.explorationManager.RemoveExplorationEvents(questEventBelongsTo);
    }
}
