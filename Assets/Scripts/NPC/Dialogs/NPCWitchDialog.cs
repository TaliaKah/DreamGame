using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class NPCWitchDialog : NPCDialog
{
    public NPCConversation meetingConversation;
    public NPCConversation casualConversation;
    public NPCConversation quest3Conversation;

    private DecisionManager decisionManager;

    void Start()
    {
        decisionManager = FindObjectOfType<DecisionManager>();
    }

    private void OnMouseOver()
    {
        AddDialogCallback(() =>
        {
            if (decisionManager.GetDecision(DecisionManager.Decision.DebuterQuete3))
            {
                ConversationManager.Instance.StartConversation(quest3Conversation);
                ConversationManager.Instance.SetBool("Avoir rencontré sorcière", decisionManager.GetDecision(DecisionManager.Decision.RencontrerSorciere));
            }
            else
            {
                if (decisionManager.GetDecision(DecisionManager.Decision.RencontrerSorciere))
                {
                    ConversationManager.Instance.StartConversation(meetingConversation);
                }
                else
                {
                    ConversationManager.Instance.StartConversation(casualConversation);
                }
            }
        });
    }
}
