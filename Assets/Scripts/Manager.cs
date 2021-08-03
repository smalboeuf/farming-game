using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{

    [SerializeField] private GameTileManager setTileManager;
    public static GameTileManager gameTileManager;

    [SerializeField] private Character setCharacter;
    public static Character character;

    [SerializeField] private InventoryManager setInventoryManager;
    public static InventoryManager inventoryManager;

    [SerializeField] private HotbarManager setHotbarManager;
    public static HotbarManager hotbarManager;

    [SerializeField] private CropsTileManager setCropsTileManager;
    public static CropsTileManager cropsTileManager;

    [SerializeField] private DateManager setDateManager;
    public static DateManager dateManager;

    [SerializeField] private QuestManager setQuestManager;
    public static QuestManager questManager;

    [SerializeField] private RelationshipManager setRelationshipManager;
    public static RelationshipManager relationshipManager;

    [SerializeField] private SkillsManager setSkillsManager;
    public static SkillsManager skillsManager;

    [SerializeField] private DialogueManager setDialogueManager;
    public static DialogueManager dialogueManager;

    private void Awake()
    {
        gameTileManager = setTileManager;
        character = setCharacter;
        inventoryManager = setInventoryManager;
        hotbarManager = setHotbarManager;
        cropsTileManager = setCropsTileManager;
        dateManager = setDateManager;
        questManager = setQuestManager;
        relationshipManager = setRelationshipManager;
        skillsManager = setSkillsManager;
        dialogueManager = setDialogueManager;
    }

    private void Start()
    {
        inventoryManager.SetStartingItems();
        inventoryManager.InitializeHotbar();
    }

}
