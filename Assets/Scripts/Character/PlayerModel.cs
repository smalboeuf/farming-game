using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    // Animators
    [SerializeField] private Animator hairAnimator;
    [SerializeField] private SpriteRenderer hairSpriteRenderer;
    [SerializeField] private Animator eyesAnimator;
    [SerializeField] private SpriteRenderer eyesSpriteRenderer;
    [SerializeField] private Animator handsAnimator;
    [SerializeField] private Animator shirtAnimator;
    [SerializeField] private Animator pantsAnimator;
    [SerializeField] private Animator bootsAnimator;
    [SerializeField] private Animator skinAnimator;

    // Appearance Category Collections
    [SerializeField] private AppearanceCategoryCollection hairCollection;
    [SerializeField] private AppearanceCategoryCollection eyesCollection;
    [SerializeField] private AppearanceCategoryCollection shirtCollection;
    [SerializeField] private AppearanceCategoryCollection handsCollection;
    [SerializeField] private AppearanceCategoryCollection pantsCollection;
    [SerializeField] private AppearanceCategoryCollection bootsCollection;
    [SerializeField] private AppearanceCategoryCollection skinCollection;

    private CharacterProfile selectedProfile;

    public void SetPlayerModel()
    {
        // Get the load file
        SaveData saveData = SaveSystem.LoadSaveData();
        selectedProfile = saveData._characterProfile;

        // Set Hair Animator
        hairAnimator.runtimeAnimatorController = hairCollection.GetAppearanceOption(selectedProfile.hairOption).GetAnimatorController();

        // Set Hair Color
        hairSpriteRenderer.color = new Color(selectedProfile.hairColor._r, selectedProfile.hairColor._g, selectedProfile.hairColor._b, selectedProfile.hairColor._a);

        // Set Eyes Animator
        eyesAnimator.runtimeAnimatorController = eyesCollection.GetAppearanceOption(selectedProfile.eyeOption).GetAnimatorController();

        // Set Eyes Color
        eyesSpriteRenderer.color = new Color(selectedProfile.eyeColor._r, selectedProfile.eyeColor._g, selectedProfile.eyeColor._b, selectedProfile.eyeColor._a);

        // Set Shirt Animator
        shirtAnimator.runtimeAnimatorController = shirtCollection.GetAppearanceOption(selectedProfile.shirtOption).GetAnimatorController();

        // Set Hands Animator
        handsAnimator.runtimeAnimatorController = handsCollection.GetAppearanceOption(selectedProfile.handsOption).GetAnimatorController();

        // Set Pants Animator
        pantsAnimator.runtimeAnimatorController = pantsCollection.GetAppearanceOption(selectedProfile.pantsOption).GetAnimatorController();

        // Set Boots Animator
        bootsAnimator.runtimeAnimatorController = bootsCollection.GetAppearanceOption(selectedProfile.bootsOption).GetAnimatorController();

        // Set Skin Animator
        skinAnimator.runtimeAnimatorController = skinCollection.GetAppearanceOption(selectedProfile.skinOption).GetAnimatorController();
    }

    public void HandleModelAnimators(Vector3 change)
    {
        if (change != Vector3.zero)
        {
            // Hair
            hairAnimator.SetFloat("moveX", change.x);
            hairAnimator.SetFloat("moveY", change.y);
            hairAnimator.SetBool("moving", true);

            // Eyes
            eyesAnimator.SetFloat("moveX", change.x);
            eyesAnimator.SetFloat("moveY", change.y);
            eyesAnimator.SetBool("moving", true);

            // Shirt
            shirtAnimator.SetFloat("moveX", change.x);
            shirtAnimator.SetFloat("moveY", change.y);
            shirtAnimator.SetBool("moving", true);

            // Hands
            handsAnimator.SetFloat("moveX", change.x);
            handsAnimator.SetFloat("moveY", change.y);
            handsAnimator.SetBool("moving", true);

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

            // Eyes
            eyesAnimator.SetBool("moving", false);

            // Shirt
            shirtAnimator.SetBool("moving", false);

            // Hands
            handsAnimator.SetBool("moving", false);

            // Pants
            pantsAnimator.SetBool("moving", false);

            // Boots
            bootsAnimator.SetBool("moving", false);

            // Skin
            skinAnimator.SetBool("moving", false);
        }

    }
}
