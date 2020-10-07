using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopItemUI : MonoBehaviour
{

    [SerializeField] private ShopItem shopItem;

    [SerializeField] private Image shopItemImage;
    [SerializeField] private TextMeshProUGUI shopItemStock;


    private Color normalColor = Color.white;
    private Color disabledColor = new Color(1, 1, 1, 0);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetUpShopUI() {

        if (shopItem == null)
        {
            shopItemImage.color = disabledColor;
            shopItemStock.color = disabledColor;
        }
        else {
            shopItemImage.color = normalColor;
            shopItemStock.color = normalColor;

            shopItemImage.sprite = shopItem.thisItem.itemImage;
            shopItemStock.text = shopItem.stock.ToString();

            if (shopItem.thisItem.unique)
            {
                shopItemStock.color = disabledColor;
            } else {
                shopItemStock.color = normalColor;
            }


            if (shopItem.stock <= 1)
            {
                shopItemStock.color = disabledColor;
            }
            else if (shopItem.stock > 1) {
                shopItemStock.color = normalColor;
            }
            
        }

    }
}
