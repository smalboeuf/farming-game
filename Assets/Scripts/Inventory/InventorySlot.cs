using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class InventorySlot : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{

    [Header("UI components to change")]
    [SerializeField] public TextMeshProUGUI itemNumberText;
    [SerializeField] public Image itemImage;

    public int hotbarPosition;

    private Color normalColor = Color.white;
    private Color disabledColor = new Color(1, 1, 1, 0);


    //Events
    public event Action<InventorySlot> OnPointerEnterEvent;
    public event Action<InventorySlot> OnPointerExitEvent;
    public event Action<InventorySlot> OnBeginDragEvent;
    public event Action<InventorySlot> OnEndDragEvent;
    public event Action<InventorySlot> OnDragEvent;
    public event Action<InventorySlot> OnDropEvent;


    private InventoryItem slottedItem;
    public InventoryItem Item {

        get
        {
            return slottedItem;
        }
        set
        {
            slottedItem = value;

            if (slottedItem == null) {
                itemImage.color = disabledColor;
            }
            else if (slottedItem != null)
            {
                itemImage.sprite = slottedItem.itemImage;
                itemImage.color = normalColor;
            }

        }
    }

    private int currentStack;
    public int Amount
    {
        get { return currentStack; }
        set
        {
            currentStack = value;
            if (currentStack < 0) currentStack = 0;
            if (currentStack == 0) Item = null;

            if (itemNumberText != null)
            {
                itemNumberText.enabled = slottedItem != null && currentStack > 1;
                if (itemNumberText.enabled)
                {
                    itemNumberText.text = currentStack.ToString();
                }
            }
        }
    }


    public virtual bool CanRecieveItem(InventoryItem item)
    {
        return true;
    }

    private void SetAlpha(float alphaValue) {
        Color temp = itemImage.color;
        temp.a = alphaValue;
        itemImage.color = temp;
    }



    public bool CanStackItem(InventoryItem item, int amount = 1) {
    
        return Item != null && Item.ID == item.ID && Amount + amount <= item.maxStack;
    }

    public void OnPointerEnter(PointerEventData eventData) {

        //Show tooltip for hovered Item
        if (OnPointerEnterEvent != null) {
            OnPointerEnterEvent(this);
        }

    }

    public void OnPointerExit(PointerEventData eventData) {

        //Hide tooltip for hovered Item
        if (OnPointerExitEvent != null) {
            OnPointerExitEvent(this);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (OnBeginDragEvent != null) {
            OnBeginDragEvent(this);
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (OnEndDragEvent != null) {
            OnEndDragEvent(this);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (OnDragEvent != null) {
            OnDragEvent(this);
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (OnDropEvent != null) {
            OnDropEvent(this);
        }
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
