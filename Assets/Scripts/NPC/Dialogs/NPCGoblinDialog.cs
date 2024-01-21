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
        if (Input.GetMouseButtonDown(0))
        {
            ConversationManager.Instance.StartConversation(casualConversation);
            ConversationManager.Instance.SetBool("Avoir autorisation", decisionManager.GetDecision(DecisionManager.Decision.AllerAuChateau));
        }
    }
    
}
