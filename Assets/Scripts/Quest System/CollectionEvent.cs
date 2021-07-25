using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionEvent : MonoBehaviour
{
    public ItemCollectionDemand itemCollectionDemand;
    public CollectionQuest questEventBelongsTo;

    public void CollectDemandItem(InventoryItem item, int amount)
    {
        if ((itemCollectionDemand.amountCollected + amount) >= itemCollectionDemand.amountRequired)
        {
            itemCollectionDemand.amountCollected = itemCollectionDemand.amountRequired;
            itemCollectionDemand.completed = true;
        }
        else {
            itemCollectionDemand.amountCollected += amount;
        }

        //Check if all items for quest is completed
        if (questEventBelongsTo.CheckIfAllItemsCollected())
        {
            //All items collected
            Manager.questManager.CompleteQuest(questEventBelongsTo);
        }
    }
}
