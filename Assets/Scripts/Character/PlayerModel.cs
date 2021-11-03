using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    [SerializeField] private Animator hairAnimator;
    [SerializeField] private Animator shirtAnimator;
    [SerializeField] private Animator pantsAnimator;
    [SerializeField] private Animator bootsAnimator;
    [SerializeField] private Animator skinAnimator;

    public void SetPlayerModel()
    {

    }

    public void HandleModelAnimators(Vector3 change)
    {
        if (change != Vector3.zero)
        {
            // Hair
            hairAnimator.SetFloat("moveX", change.x);
            hairAnimator.SetFloat("moveY", change.y);
            hairAnimator.SetBool("moving", true);

            // Shirt
            shirtAnimator.SetFloat("moveX", change.x);
            shirtAnimator.SetFloat("moveY", change.y);
            shirtAnimator.SetBool("moving", true);

            // Pants
            pantsAnimator.SetFloat("moveX", change.x);
            pantsAnimator.SetFloat("moveY", change.y);
            pantsAnimator.SetBool("moving", true);

            // Boots
            bootsAnimator.SetFloat("moveX", change.x);
            bootsAnimator.SetFloat("moveY", change.y);
            bootsAnimator.SetBool("moving", true);

            // Skin
            skinAnimator.SetFloat("moveX", change.x);
            skinAnimator.SetFloat("moveY", change.y);
            skinAnimator.SetBool("moving", true);
        }
        else
        {
            // Hair
            hairAnimator.SetBool("moving", false);

            // Shirt
            shirtAnimator.SetBool("moving", false);

            // Pants
            pantsAnimator.SetBool("moving", false);

            // Boots
            bootsAnimator.SetBool("moving", false);

            // Skin
            skinAnimator.SetBool("moving", false);
        }

    }
}
