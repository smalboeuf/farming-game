using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{

    [SerializeField] private GameTileManager setTileManager;
    public static GameTileManager gameTileManager;

    [SerializeField] private Character setCharacter;
    public static Character character;

    [SerializeField] private InventoryManager setInventoryManager;
    public static InventoryManager inventoryManager;

    [SerializeField] private HotbarManager setHotbarManager;
    public static HotbarManager hotbarManager;

    [SerializeField] private CropsTileManager setCropsTileManager;
    public static CropsTileManager cropsTileManager;

    [SerializeField] private DateManager setDateManager;
    public static DateManager dateManager;

 



    // Start is called before the first frame update
    void Start()
    {
        gameTileManager = setTileManager;
        character = setCharacter;
        inventoryManager = setInventoryManager;
        hotbarManager = setHotbarManager;
        cropsTileManager = setCropsTileManager;
        dateManager = setDateManager;
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
