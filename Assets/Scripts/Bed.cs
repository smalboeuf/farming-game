using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //Prompt user to go to bed
            TriggerSleepChoice();
            HandleSleepChoice(true);
        }
    }

    private void TriggerSleepChoice()
    {

    }

    private void HandleSleepChoice(bool userChoice)
    {
        if (userChoice)
        {
            // Go to the next day
            print("Next day triggered!");
            Manager.dateManager.NextDay();
        }
    }
}
