using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private Animator animator;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    

    private Queue<string> sentences;

    private bool inDialogue = false;
    
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && inDialogue)
        {
            DisplayNextSentece();
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        //Hide hotbar

        inDialogue = true;
        nameText.text = dialogue.name;
        sentences.Clear();

        dialoguePanel.SetActive(true);

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentece();
    }

    private void DisplayNextSentece()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";

        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.025f);
        }
    }

    private void EndDialogue()
    {
        //End the dialogue and close the window
        dialoguePanel.SetActive(false);
        inDialogue = false;
        //Show hotbar

    }
}
