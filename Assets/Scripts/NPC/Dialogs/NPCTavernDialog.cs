using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class NPCTavernDialog : NPCDialog
{
    public NPCConversation meetingConversation;
    public NPCConversation casualConversation;

    private DecisionManager decisionManager;

    void Start()
    {
        decisionManager = FindObjectOfType<DecisionManager>();
    }

    private void OnMouseOver()
    {
        AddDialogCallback(() =>
        {
            if (decisionManager.GetDecision(DecisionManager.Decision.RencontrerLeTavernier))
            {
                ConversationManager.Instance.StartConversation(casualConversation);
            }
            else
            {
                ConversationManager.Instance.StartConversation(meetingConversation);
                ConversationManager.Instance.SetBool("EtreChevalier", decisionManager.GetDecision(DecisionManager.Decision.AccepterDeDevenirChevalier));
            }
        });
    }
}
