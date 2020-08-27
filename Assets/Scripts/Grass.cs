using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : MonoBehaviour
{

    // private Grass[][] grassTiles = new Grass[][];

    [SerializeField] private Sprite tilledPlot;
    [SerializeField] private Sprite planted;
    [SerializeField] private Sprite wateredAndPlanted;
    [SerializeField] private Sprite watered;
    [SerializeField] private HotbarManager playerHotbar;


    public Character player;

    private SpriteRenderer spriteRenderer;

    public enum TileStatus
    {
        Grass,
        Tilled,
        Planted,
        Watered,
        WateredAndPlanted
    };

    private TileStatus tileStatus;



    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        //plantStatusCheck();
        
    }


    /*private void plantStatusCheck() {


        if (checkIfInRange())
        {

            if (tileStatus == TileStatus.Grass && playerHotbar.IsAHoe())
            {
                spriteRenderer.sprite = tilledPlot;
                tileStatus = TileStatus.Tilled;
            }
            else if (tileStatus == TileStatus.Tilled)
            {
                if (playerHotbar.IsSeeds())
                {
                    spriteRenderer.sprite = planted;
                    tileStatus = TileStatus.Planted;
                }
                else if (playerHotbar.CanWaterSeeds()) {

                    spriteRenderer.sprite = watered;
                    tileStatus = TileStatus.Watered;
                }

            }
            else if (tileStatus == TileStatus.Planted && playerHotbar.CanWaterSeeds())
            {
                spriteRenderer.sprite = wateredAndPlanted;
                tileStatus = TileStatus.WateredAndPlanted;

            } else if (tileStatus == TileStatus.Watered && playerHotbar.IsSeeds()){

                spriteRenderer.sprite = wateredAndPlanted;
                tileStatus = TileStatus.WateredAndPlanted;
            }
            

        }
        else {
            Debug.Log("Out of range");
        }

       
    } */

    private bool checkIfInRange() {

        if (Vector3.Distance(player.transform.position, transform.position) <= player.range)
        {
            return true;
        }
        else {
            return false;
        }
        
    }
}

