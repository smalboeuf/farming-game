using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Collection Quest", menuName = "Quest System/Quest/Collection")]
public class CollectionQuest : Quest
{
    public List<ItemCollectionDemand> itemDemands;
    public List<ItemCollectionDemand> handedInItems;
    private bool isCollected = false;

    public bool CheckIfAllItemsCollected()
    {
        int completedDemands = 0;

        for (int i = 0; i < itemDemands.Count; i++)
        {
            if (itemDemands[i].collected)
            {
                completedDemands++;
            }
        }
        if (completedDemands == itemDemands.Count)
        {
            isCollected = true;
        }
        return isCollected;
    }

    public void HandInItem(InventoryItem item)
    {
        for (int i = 0; i < itemDemands.Count; i++)
        {
            if (itemDemands[i].item.ID == item.ID && !itemDemands[i].collected)
            {
                handedInItems.Add(itemDemands[i]);
                itemDemands.RemoveAt(i);

                CheckIfAllItemsCollected();
            }
        }
    }

    public bool isItemsCollected()
    {
        return isCollected;
    }
}
