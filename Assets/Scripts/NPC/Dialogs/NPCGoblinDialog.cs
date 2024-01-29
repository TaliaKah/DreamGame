using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class NPCGoblinDialog : NPCDialog
{
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
            ConversationManager.Instance.StartConversation(casualConversation);
            ConversationManager.Instance.SetBool("Avoir autorisation", decisionManager.GetDecision(DecisionManager.Decision.AllerAuChateau));
            ConversationManager.Instance.SetBool("Prison", decisionManager.GetDecision(DecisionManager.Decision.AllerEnPrison));
        });
    }

}
