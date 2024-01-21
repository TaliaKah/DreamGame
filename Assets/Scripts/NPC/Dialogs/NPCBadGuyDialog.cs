using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class NPCBadGuyDialog : NPCDialog
{
    public NPCConversation fightConversation;

    private DecisionManager decisionManager;

    void Start()
    {
        decisionManager = FindObjectOfType<DecisionManager>();
    }

    private void OnMouseOver()
    {
        base.MouseOver(() =>
        {
            if (!decisionManager.GetDecision(DecisionManager.Decision.TaperMechant))
            {
                ConversationManager.Instance.StartConversation(fightConversation);
            }
        });
    }

}
