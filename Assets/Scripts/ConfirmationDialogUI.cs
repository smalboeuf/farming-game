using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ConfirmationDialogUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI confirmationText;
    [SerializeField]
    private Button yesButton;
    [SerializeField]
    private Button noButton;

    public void ShowQuestion(string questionText, Action yesAction, Action noAction)
    {
        confirmationText.text = questionText;
        yesButton.onClick.AddListener(() =>
        {
            Hide();
            yesAction();
        });

        noButton.onClick.AddListener(() =>
        {
            Hide();
            noAction();
        });

        Show();
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
