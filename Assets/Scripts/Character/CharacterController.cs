using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Animator animator;
    private Vector3 change;
    private Character character;
    private NPC npcInRange;

    [SerializeField] private PlayerModel playerModel;


    [SerializeField]
    private ConfirmationDialogUI confirmationDialogUI;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        character = GetComponent<Character>();
    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");

        // Right click 
        HandleInteractClick();
        InteractWithNPC();
        UpdateAnimationAndMove();
    }

    private void FixedUpdate()
    {
        if (Manager.character.CanMove)
        {
            MoveCharacter();
        }
    }

    public Vector2 GetCharacterFacingDirection()
    {
        if (animator != null)
        {
            return new Vector2(animator.GetFloat("moveX"), animator.GetFloat("moveY"));
        }

        return new Vector2(0, 0);
    }

    void UpdateAnimationAndMove()
    {
        if (Manager.character.CanMove == true)
        {
            if (change != Vector3.zero)
            {
                MoveCharacter();
            }
            playerModel.HandleModelAnimators(change);
        }
    }

    private void MoveCharacter()
    {
        rb.MovePosition(transform.position + change.normalized * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "NPC")
        {
            npcInRange = collision.GetComponent<NPC>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "NPC")
        {
            npcInRange = null;
        }
    }

    private void InteractWithNPC()
    {
        if (Input.GetKeyDown(KeyCode.F) && npcInRange != null)
        {
            npcInRange.StartNPCInteraction();
        }
    }

    void HandleInteractClick()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (character.CanMove)
            {
                Vegetation vegetation = GetVegetationOnMousePosition();
                Vector3 clickedPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                // Gift item to NPC
                if (npcInRange != null)
                {
                    NPC npc = GetNPCOnMousePosition();
                    if (npcInRange.fullName == npc.fullName)
                    {
                        InventoryItem selectedItem = Manager.hotbarManager.GetSelectedItem();

                        if (selectedItem != null && selectedItem.canBeGifted)
                        {
                            print("Give item to " + npc);
                            // Giving item to NPC
                            HandleGivingItemToNPC(npc);
                        }
                    }
                }
                else if (vegetation != null && vegetation.CanBeHarvested() && character.IsInRange(clickedPosition))
                {
                    vegetation.HarvestVegetation();
                }
                else if (character.CanPickUpItem(clickedPosition))
                {
                    // Harvest crop
                    character.HarvestCrop(clickedPosition);
                }
                else if (Manager.hotbarManager.GetSelectedItem() is Seed seed)
                {
                    // Plant seed
                    seed.UseSeed(seed, (int)clickedPosition.x, (int)clickedPosition.y);
                }
                else if (Manager.hotbarManager.GetSelectedItem() is Consumable consumable)
                {
                    InventoryItem selectedItem = Manager.hotbarManager.GetSelectedItem();
                    // Consume item in inventory
                    confirmationDialogUI.ShowQuestion($"Are you sure you want to use the {selectedItem.itemName}?", () =>
                    {
                        consumable.OnUse();
                    }, () => { });
                }
            }
        }
    }

    private NPC GetNPCOnMousePosition()
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        foreach (RaycastHit2D hit in hits)
        {
            if (hit.collider.gameObject.GetComponent<NPC>() != null)
            {
                NPC npc = hit.collider.gameObject.GetComponent<NPC>();
                return npc;
            }
        }

        return null;
    }

    private Vegetation GetVegetationOnMousePosition()
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        foreach (RaycastHit2D hit in hits)
        {
            if (hit.collider.gameObject.GetComponent<Vegetation>() != null)
            {
                Vegetation vegetation = hit.collider.gameObject.GetComponent<Vegetation>();
                return vegetation;
            }
        }

        return null;
    }

    void HandleGivingItemToNPC(NPC npc)
    {
        print("Giving item to NPC");
        InventoryItem itemGiven = Manager.hotbarManager.GetSelectedItem();
        // Remove item from the players inventory
        Manager.inventoryManager.RemoveItemAtHotbarIndex(Manager.hotbarManager.selectedSlot, itemGiven);
        // Add relationship experience from gift
        Manager.relationshipManager.AddExperienceToRelationshipBasedOnItem(itemGiven, npc);
        // Check to see if the item is for a quest
        Manager.questManager.CheckIfGiftCompletesQuest(itemGiven, npc);
    }

    private static Ray GetMouseRay()
    {
        return Camera.main.ScreenPointToRay(Input.mousePosition);
    }
}
