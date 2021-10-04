using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionEvent : MonoBehaviour
{
    public ItemCollectionDemand itemCollectionDemand;
    public CollectionQuest questEventBelongsTo;

    public void CollectDemandItem(InventoryItem item, int amount)
    {
        itemCollectionDemand.collected = true;

        //Check if all items for quest is completed
        if (questEventBelongsTo.CheckIfAllItemsCollected())
        {
            //All items collected
            //Manager.questManager.CompleteQuest(questEventBelongsTo);
            Manager.questManager.FulfillQuestNeeds(questEventBelongsTo);
            Manager.inventoryManager.RemoveCollectionEvents(questEventBelongsTo);
        }
    }
}
