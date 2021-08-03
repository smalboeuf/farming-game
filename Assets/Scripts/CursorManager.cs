using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorManager : MonoBehaviour
{

    [SerializeField] private Texture2D defaultCursor;
    [SerializeField] private Texture2D pickupCursor;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(pickupCursor, Vector2.zero, CursorMode.Auto);

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

       

        if (Manager.gameTileManager.IsAValidTile((int)cursorPosition.x, (int)cursorPosition.y)) { 

            GameTile currentTile = Manager.gameTileManager.gameTileMap[(int)cursorPosition.x, (int)cursorPosition.y];
                
            if (currentTile.GetCanBeHarvested() == true)
            {
                Cursor.SetCursor(pickupCursor, Vector2.zero, CursorMode.Auto);
            }
            else
            {
                Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.Auto);
            }

        }

    }


   
}
