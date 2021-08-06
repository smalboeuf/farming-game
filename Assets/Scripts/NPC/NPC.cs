using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public string firstName;
    public string lastName;
    public string fullName;
    private QuestGiver questGiver;

    public DialogueChannel dialogueChannel;
    public Dialogue dialogue;

    [SerializeField] private DialogueManager dialogueManager;

    // Start is called before the first frame update
    void Start()
    {
        questGiver = GetComponent<QuestGiver>();
        dialogue.name = fullName;
    }
    
    public QuestGiver GetQuestGiver()
    {
        return questGiver;
    }

    public void StartNPCInteraction() {

        if (questGiver != null)
        {
            //Offer player a quest
            List<Quest> availableQuests = questGiver.GetAvailableQuests();
            print(availableQuests);

            for (int i = 0; i < availableQuests.Count; i++)
            {
                questGiver.DeliverQuest(availableQuests[i]);
            }
        }

        StartDialogue();
    }

    public void StartDialogue()
    {
        //Manager.dialogueManager.StartDialogue(dialogue);
        dialogueChannel.RaiseRequestDialogue(dialogue);
    }

    public void OfferQuestToPlayer()
    {

    }
    
}
