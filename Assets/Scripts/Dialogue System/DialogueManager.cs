using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour, DialogueNodeVisitor
{
    [SerializeField]
    private GameObject dialoguePanel;

    [SerializeField]
    private TextMeshProUGUI m_SpeakerText;
    [SerializeField]
    private TextMeshProUGUI m_DialogueText;
    [SerializeField]
    private Image m_portraitImage;

    [SerializeField]
    private RectTransform m_ChoicesBoxTransform;
    [SerializeField]
    private UIDialogueChoiceController m_ChoiceControllerPrefab;

    [SerializeField]
    private DialogueChannel m_DialogueChannel;

    private bool m_ListenToInput = false;
    private DialogueNode m_NextNode = null;

    private void Awake()
    {
        m_DialogueChannel.OnDialogueNodeStart += OnDialogueNodeStart;
        m_DialogueChannel.OnDialogueNodeEnd += OnDialogueNodeEnd;

        dialoguePanel.gameObject.SetActive(false);
        m_ChoicesBoxTransform.gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        m_DialogueChannel.OnDialogueNodeEnd -= OnDialogueNodeEnd;
        m_DialogueChannel.OnDialogueNodeStart -= OnDialogueNodeStart;
    }

    private void Update()
    {
        if (m_ListenToInput && Input.GetMouseButtonDown(0))
        {
            m_DialogueChannel.RaiseRequestDialogueNode(m_NextNode);
        }
    }

    private void OnDialogueNodeStart(DialogueNode node)
    {
        dialoguePanel.gameObject.SetActive(true);

        //m_DialogueText.text = node.DialogueLine.Text;
        StopAllCoroutines();
        SetDialoguePortaitImage(node);
        StartCoroutine(TypeSentence(node.DialogueLine.Text));
        m_SpeakerText.text = node.DialogueLine.Speaker.CharacterName;


        node.Accept(this);
    }

    private void SetDialoguePortaitImage(DialogueNode node)
    {
        if (node.portraitEmotion == DialogueNode.PortraitEmotion.Normal)
        {
            m_portraitImage.sprite = node.DialogueLine.Speaker.normalPortrait;
        }

        if (node.portraitEmotion == DialogueNode.PortraitEmotion.Sad)
        {
            m_portraitImage.sprite = node.DialogueLine.Speaker.sadPortrait;
        }
    }

    private void OnDialogueNodeEnd(DialogueNode node)
    {
        m_NextNode = null;
        m_ListenToInput = false;
        m_DialogueText.text = "";
        m_SpeakerText.text = "";

        foreach (Transform child in m_ChoicesBoxTransform)
        {
            Destroy(child.gameObject);
        }

        dialoguePanel.gameObject.SetActive(false);
        m_ChoicesBoxTransform.gameObject.SetActive(false);
    }

    public void Visit(BasicDialogueNode node)
    {
        m_ListenToInput = true;
        m_NextNode = node.NextNode;

        //Give quest if node has a quest to give
        if (node.questToGive != null)
        {
            Manager.questManager.AcceptQuest(node.questToGive);
        }
    }

    public void Visit(ChoiceDialogueNode node)
    {
        m_ChoicesBoxTransform.gameObject.SetActive(true);

        foreach (DialogueChoice choice in node.Choices)
        {
            UIDialogueChoiceController newChoice = Instantiate(m_ChoiceControllerPrefab, m_ChoicesBoxTransform);
            newChoice.Choice = choice;
        }
    }

    IEnumerator TypeSentence(string sentence)
    {
        m_DialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            m_DialogueText.text += letter;
            yield return new WaitForSeconds(0.025f);
        }
    }
}
