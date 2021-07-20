using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Collection Quest", menuName = "Quest System/Quest/Collection")]
public class CollectionQuest : Quest
{
    public List<ItemCollectionDemand> itemDemands;
}
