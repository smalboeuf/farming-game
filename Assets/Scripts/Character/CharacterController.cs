using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

    public float speed;
    private Rigidbody2D rb;
    private Animator animator;
    private Vector3 change;
    private NPC npcInRange;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");

        UpdateAnimationAndMove();
        InteractWithNPC();
        GiveItemToNPC();
    }

    private void FixedUpdate()
    {
        if (Manager.character.GetCanMove() == true) {
            MoveCharacter();
        }
    }

    void UpdateAnimationAndMove() {

        if (Manager.character.GetCanMove() == true)
        {
            if (change != Vector3.zero)
            {
                MoveCharacter();
                animator.SetFloat("moveX", change.x);
                animator.SetFloat("moveY", change.y);
                animator.SetBool("moving", true);
            }
            else
            {
                animator.SetBool("moving", false);
            }
        }
    }

    void MoveCharacter() {
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

    void InteractWithNPC()
    {
        if (Input.GetKeyDown(KeyCode.F) && npcInRange != null)
        {
            npcInRange.StartNPCInteraction();
        }
    }

    void GiveItemToNPC()
    {
        if (Input.GetMouseButtonDown(1))
        {
            print("Right clicked and trying to gift an item to an NPC");

            InventoryItem selectedItem = Manager.hotbarManager.GetSelectedItem();

            if (selectedItem != null && selectedItem.canBeGifted)
            {
                print("got here");
                RaycastHit2D[] hits = Physics2D.RaycastAll(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

                foreach (RaycastHit2D hit in hits)
                {
                    print(hit.collider.gameObject);
                    if (hit.collider.gameObject.GetComponent<NPC>() != null)
                    {
                        // Giving item to NPC
                        print("Giving item to NPC");
                        // Remove item from the players inventory

                        // Check to see if the item is for a quest
                        
                        // Increase the relationship between the player and the NPC
                    }
                }               
            }
        }
    }

    void HandleGivingItemToNPC()
    {
    }

    private static Ray GetMouseRay()
    {
        return Camera.main.ScreenPointToRay(Input.mousePosition);
    }
}
