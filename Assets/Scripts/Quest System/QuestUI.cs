using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestUI : MonoBehaviour
{
    public Quest quest;

    [SerializeField] private TextMeshProUGUI questName;

    public void SetQuestUIElements(Quest newQuest)
    {
        //Set UI elements based on the quest
        quest = newQuest;
        questName.text = newQuest.QuestName;
        Button button = GetComponent<Button>();
        button.onClick.AddListener(delegate {
            Manager.questManager.ToggleQuestPanel();
            Manager.questManager.questDescriptionPanel.ClickOnQuest(quest);
        });
    }
}
