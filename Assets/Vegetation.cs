using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vegetation : MonoBehaviour
{
    [SerializeField] private bool canBeHarvested = true;
    [SerializeField] private Sprite harvestableSprite;
    [SerializeField] private Sprite notHarvestableSprite;
    [SerializeField] private InventoryItem itemToBeHarvested;
    [SerializeField] private int minHarvestAmount = 1;
    [SerializeField] private int maxHarvestAmount = 5;

    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void HarvestVegetation()
    {
        if (canBeHarvested)
        {
            int randomHarvestAmount = Random.Range(minHarvestAmount, maxHarvestAmount);
            Manager.inventoryManager.AddItem(itemToBeHarvested, randomHarvestAmount);

            spriteRenderer.sprite = notHarvestableSprite;
            canBeHarvested = false;
            print("Harvested");
        }
    }

    public void GrowVegetation()
    {
        spriteRenderer.sprite = harvestableSprite;
        canBeHarvested = true;
    }

    public bool CanBeHarvested()
    {
        return canBeHarvested;
    }
}
