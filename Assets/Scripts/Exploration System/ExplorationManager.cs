using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplorationManager : MonoBehaviour
{
    public List<ExplorationEvent> explorationEvents = new List<ExplorationEvent>();

    // Prefab
    public GameObject explorationPoint;

    public void ExploreArea(ExplorationArea explorationArea)
    {
        CheckExplorationEvents(explorationArea);
    }

    public void InstantiateExplorationPoint(ExplorationQuest explorationQuest)
    {
        ExplorationArea explorationArea = explorationQuest.explorationArea;
        Instantiate(explorationPoint, new Vector3(explorationArea.x, explorationArea.y, 0), Quaternion.identity);
    }

    public void AddExplorationEvents(ExplorationQuest explorationQuest)
    {
        explorationEvents.Add(
            new ExplorationEvent
            {
                explorationArea = explorationQuest.explorationArea,
                questEventBelongsTo = explorationQuest
            });
    }

    private void CheckExplorationEvents(ExplorationArea explorationArea)
    {
        for (int i = 0; i < explorationEvents.Count; i++)
        {
            if (explorationEvents[i].explorationArea.areaName == explorationArea.areaName)
            {
                print("ExplorationEvent triggered");
                // If exploration event exists, explore and remove exploration event
                explorationEvents[i].ExploreExplorationArea();
            }
        }
    }

    public void RemoveExplorationEvents(ExplorationQuest explorationQuest)
    {
        for (int i = 0; i < explorationEvents.Count; i++)
        {
            if (explorationEvents[i].questEventBelongsTo.ID == explorationQuest.ID)
            {
                // Remove ExplorationEvent from completed Quest
                explorationEvents.RemoveAt(i);
            }
        }
    }
}
