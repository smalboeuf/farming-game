using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [Header("Quest Manager Data")]
    public List<Quest> activeQuests;
    public List<Quest> completedQuests;

    [Header("UI GameObjects")]
    [SerializeField] private GameObject questPanelContent;
    [SerializeField] private GameObject questUIPrefab;
    public QuestDescriptionPanel questDescriptionPanel;

    public Quest TestQuest;

    private void Start()
    {
        InitializeQuestPanel();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            print("Adding quest");
            this.AcceptQuest(TestQuest);
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            print("Completing quest");
            this.CompleteQuest(TestQuest);
        }
    }

    public void ToggleQuestPanel() {
        gameObject.SetActive(!gameObject.activeSelf);
        questDescriptionPanel.gameObject.SetActive(false);
        if (gameObject.activeSelf == true)
        {
            Manager.character.SetCanMove(false);
        }
        else {
            Manager.character.SetCanMove(true);
        }
    }

    private void InitializeQuestPanel()
    {
        for (int i = 0; i < activeQuests.Count; i++)
        {
            CreateQuestUI(activeQuests[i]);
        }
    }

    private void RemoveQuestUI(Quest quest)
    {
        foreach (Transform child in questPanelContent.transform)
        {
            QuestUI questTransformUI = child.GetComponent<QuestUI>();

            if (questTransformUI.quest.ID == quest.ID)
            {
                print("removing quest UI");
                Destroy(child.gameObject);
            }
        }
    }

    private void CreateQuestUI(Quest quest)
    {
        var newQuestGameObject = Instantiate(questUIPrefab, questPanelContent.transform);
        var newQuest = newQuestGameObject.GetComponent<QuestUI>();
        newQuest.SetQuestUIElements(quest);
    }

    // Check to see if a quest is active
    public bool isActive(Quest quest)
    {
        for (int i = 0; i < activeQuests.Count; i++)
        {
            if (activeQuests[i].ID == quest.ID)
            {
                return true;
            }
        }

        return false;
    }

    // Accept a quest
    public void AcceptQuest(Quest quest)
    {
        //Set quest to active and in active list
        quest.isActive = true;
        activeQuests.Add(quest);
        CreateQuestUI(quest);

        //Add on collect events whenever quest is accepted
        if (quest.IsCollectionQuest())
        {
            Manager.inventoryManager.AddCollectionEvents((CollectionQuest)quest);
        }
    }

    public void CompleteQuest(Quest quest)
    {
        //Change scriptable object variables
        quest.isCompleted = true;
        quest.isActive = false;

        //Move to completed quest
        for (int i = 0; i < activeQuests.Count; i++)
        {
            if (activeQuests[i].ID == quest.ID)
            {
                activeQuests.RemoveAt(i);
            }
        }

        completedQuests.Add(quest);

        //Give rewards
        GiveQuestRewards(quest);

        RemoveQuestUI(quest);
    }

    public void GiveQuestRewards(Quest quest)
    {
        //Update UI after all the things have been added
        
        //Add gold to players inventory
        Manager.inventoryManager.AddGold(quest.gold);
        //Add relationship points (need to create relationship system)
        Manager.relationshipManager.AddExperienceToRelationship(quest.relationshipNPC, quest.relationshipPointsGained);
        //Add skill experience
        Manager.skillsManager.AddExperienceToSkill(quest.skillType, quest.skillExperience);

        //Loop through all reward items and add it to the inventory
        for (int i = 0; i < quest.questRewards.Count; i++)
        {
            Manager.inventoryManager.AddItem(quest.questRewards[i].inventoryItem, quest.questRewards[i].amount);
        }
    }
}
