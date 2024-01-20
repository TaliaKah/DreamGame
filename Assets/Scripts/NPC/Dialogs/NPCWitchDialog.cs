using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class NPCWitchDialog : MonoBehaviour
{
    public NPCConversation meetingConversation;
    public NPCConversation casualConversation;
    public NPCConversation quest2Conversation;

    private DecisionManager decisionManager;

    void Start()
    {
        decisionManager = FindObjectOfType<DecisionManager>();
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(decisionManager.GetDecision(DecisionManager.Decision.DebuterQuete2))
            {
                ConversationManager.Instance.StartConversation(quest2Conversation);
                ConversationManager.Instance.SetBool("Avoir rencontré sorcière", decisionManager.GetDecision(DecisionManager.Decision.RencontrerSorciere));
            }
            else
            {
                if(decisionManager.GetDecision(DecisionManager.Decision.RencontrerSorciere))
                {
                    ConversationManager.Instance.StartConversation(meetingConversation);
                }
                else
                {
                    ConversationManager.Instance.StartConversation(casualConversation);
                }
            }
        }
    }
}
