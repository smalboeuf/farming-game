using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{

    [SerializeField] private GameTileManager setTileManager;
    public static GameTileManager gameTileManager;



    // Start is called before the first frame update
    void Start()
    {
        gameTileManager = setTileManager;
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
