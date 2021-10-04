using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : MonoBehaviour
{
    [SerializeField] private ConfirmationDialogUI confirmationDialogUI;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            TriggerSleepChoice();
        }
    }

    private void TriggerSleepChoice()
    {
        confirmationDialogUI.ShowQuestion("Do you want to go to the next day?", () =>
            {
                Manager.dateManager.NextDay();
            }, () =>
            {
                // Do nothing
            });
    }
}
