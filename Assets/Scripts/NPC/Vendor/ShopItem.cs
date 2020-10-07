using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ShopItem
{

    [SerializeField] public InventoryItem thisItem;
    [SerializeField] public int stock;
    [SerializeField] public bool limitedStock;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
