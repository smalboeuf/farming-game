using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Collection Quest", menuName = "Quest System/Quest/Collection")]
public class CollectionQuest : Quest
{
    public List<ItemCollectionDemand> itemDemands;

    public bool CheckIfAllItemsCollected() {
        int completedDemands = 0; 

        for (int i = 0; i < itemDemands.Count; i++)
        {
            if (itemDemands[i].completed)
            {
                completedDemands++;
            }
        }

        return completedDemands == itemDemands.Count;
    }
}
