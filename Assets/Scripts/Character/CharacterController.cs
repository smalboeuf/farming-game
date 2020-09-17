using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

    public float speed;
    private Rigidbody2D rb;
    private Animator animator;
    private Vector3 change;


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

}
