using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using UnityEngine.UI;

public class ItemTooltip : MonoBehaviour
{
    
    [SerializeField] Text itemNameText;
    [SerializeField] Text itemDescription;

    [SerializeField] GameObject tooltipPanel;


    private void Start()
    {
        HideTooltip();
    }

    public void ShowTooltip(InventoryItem item) {
   
        if (item != null) {
          
            itemNameText.text = item.itemName;
            itemDescription.text = item.itemDescription;

            tooltipPanel.SetActive(true);
        }
        
    }

    public void HideTooltip() {
        tooltipPanel.SetActive(false);
    }

}
