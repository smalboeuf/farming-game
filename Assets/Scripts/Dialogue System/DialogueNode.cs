using UnityEngine;

public abstract class DialogueNode : ScriptableObject
{
    [SerializeField]
     private NarrationLine m_DialogueLine;

    public NarrationLine DialogueLine => m_DialogueLine;

    public Quest questToGive;

    public PortraitEmotion portraitEmotion = PortraitEmotion.Normal;

    public abstract bool CanBeFollowedByNode(DialogueNode node);
    public abstract void Accept(DialogueNodeVisitor visitor);

    public enum PortraitEmotion
    {
        Normal,
        Sad,
        Disgusted,
        Scared
    }
}


