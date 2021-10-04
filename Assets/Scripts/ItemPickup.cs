using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPickup : MonoBehaviour
{
    [SerializeField] private InventoryItem item;
    [SerializeField] private int stackQuantity;

    [SerializeField] private SpriteRenderer itemSprite;

    private bool canBePickedUp = false;

    [SerializeField] private float dropItemForce = 10f;
    private Rigidbody2D rb;

    private void Start()
    {
        itemSprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

        StartCoroutine(OnSpawnEffects());
    }

    public InventoryItem GetInventoryItem()
    {
        return item;
    }

    public void SetItem(InventoryItem inventoryItem)
    {
        item = inventoryItem;
        SetImage();
    }

    public void SetImage()
    {
        if (item != null)
        {
            itemSprite.sprite = item.itemImage;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PickupItem();
        }
    }

    public void SetStackQuantity(int amount)
    {
        stackQuantity = amount;
    }

    private void PickupItem()
    {
        if (canBePickedUp)
        {
            print("Pickup triggered");
            Manager.inventoryManager.AddItem(item, stackQuantity);
            Destroy(gameObject);
        }
    }

    IEnumerator OnSpawnEffects()
    {
        Vector2 characterFacing = GetPlayerFacingDirection();

        if (characterFacing.x == 0 && characterFacing.y == 0)
        {
            characterFacing = new Vector2(0, -1);
        }

        rb.velocity = characterFacing * dropItemForce;

        yield return new WaitForSeconds(0.25f);

        rb.velocity = Vector2.zero;

        yield return new WaitForSeconds(1.5f);

        canBePickedUp = true;
    }

    public Vector2 GetPlayerFacingDirection()
    {
        return GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterController>().GetCharacterFacingDirection();
    }
}
