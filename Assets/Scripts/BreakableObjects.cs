using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObjects : MonoBehaviour
{
    [SerializeField] private List<InventoryItem> droppableItems;
    [SerializeField] private int durability = 100;

    [SerializeField] private ToolType canBeBrokenBy;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Break();
        }
    }

    public void Break()
    {
        DropItems();
        Destroy(gameObject);
    }

    public void DropItems()
    {
        GameObject itemPickupPrefab = Manager.inventoryManager.GetItemPickupPrefab();
        for (int i = 0; i < droppableItems.Count; i++)
        {
            GameObject itemToBeDropped = itemPickupPrefab;
            ItemPickup itemPickup = itemToBeDropped.GetComponent<ItemPickup>();
            itemPickup.SetItem(droppableItems[i]);
            itemPickup.SetStackQuantity(1);
            itemPickup.SetImage();
            itemPickup.SetWasDropped(false);
            var spawnedItem = Instantiate(itemPickup, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
        }
    }
}
