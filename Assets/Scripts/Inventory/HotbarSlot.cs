using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HotbarSlot : MonoBehaviour
{

    public InventorySlot itemSlot;
    [SerializeField] Image hotbarItemIcon;
    [SerializeField] TextMeshProUGUI stackCount;
    [SerializeField] public GameObject selectionImage;

    public int slotIndex;


    private Color normalColor = Color.white;
    private Color disabledColor = new Color(1, 1, 1, 0);

    int selectedSlot = 0;

    // Start is called before the first frame update
    void Start()
    {
    
        
    }

    // Update is called once per frame
    void Update()
    {

    }



    public void enableSelection()
    {
        selectionImage.SetActive(true);
    }

    public void disableSelection()
    {
        selectionImage.SetActive(false);
    }


    public void SetHotbarSlot() {

        if (itemSlot.Item == null)
        {
            hotbarItemIcon.color = disabledColor;
            stackCount.color = disabledColor;
        }
        else {
            hotbarItemIcon.color = normalColor;
            stackCount.color = normalColor;
            hotbarItemIcon.sprite = itemSlot.itemImage.sprite;
            stackCount.text = itemSlot.Amount.ToString();

            if (itemSlot.Item.unique == true)
            {
                stackCount.color = disabledColor;
            }
            else {
                stackCount.color = normalColor;
            }

            if (itemSlot.Amount <= 1)
            {
                stackCount.color = disabledColor;
            }
            else {
                stackCount.color = normalColor;
            }
       
        }
    }

    public int GetSelectedSlot() {
        return selectedSlot;
    }


}
