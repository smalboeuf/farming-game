using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{

    public string firstName;
    public string lastName;
    public string fullName;
    private QuestGiver questGiver;
    public bool playerInRange = false;

    // Start is called before the first frame update
    void Start()
    {
        questGiver = GetComponent<QuestGiver>();
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }

    public QuestGiver GetQuestGiver()
    {
        return questGiver;
    }


}
