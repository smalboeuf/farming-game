using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.UI.Button;

public class QuestDescriptionPanel : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI questTitle;
    [SerializeField] TextMeshProUGUI questDescription;

    public void ToggleQuestDetailsPanel()
    {
        gameObject.SetActive(gameObject.activeSelf);

        if (gameObject.activeSelf == true)
        {
            Manager.character.SetCanMove(false);
        }
        else
        {
            Manager.character.SetCanMove(true);
        }
    }

    public void ShowQuestDescription()
    {
        gameObject.SetActive(true);
    }

    public void SetQuestDescriptionPanel(Quest quest)
    {
        questTitle.text = quest.QuestName;
        questDescription.text = quest.QuestDescription;
    }

    public void ClickOnQuest(Quest quest)
    {
        SetQuestDescriptionPanel(quest);
        ShowQuestDescription();
    }
}
