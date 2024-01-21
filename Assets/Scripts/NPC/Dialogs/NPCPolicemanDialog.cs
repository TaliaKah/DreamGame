using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class NPCPolicemanDialog : NPCDialog
{
    public NPCConversation casualConversation;
    public NPCConversation inJailConversation;
    public NPCConversation outOfJailConversation;

    private DecisionManager decisionManager;

    void Start()
    {
        decisionManager = FindObjectOfType<DecisionManager>();
    }

    private void OnMouseOver()
    {
        base.MouseOver(() =>
        {
            if (decisionManager.GetDecision(DecisionManager.Decision.AllerEnPrison))
            {
                if (decisionManager.GetDecision(DecisionManager.Decision.AllerALaMontagneDuDesespoir))
                {
                    ConversationManager.Instance.StartConversation(outOfJailConversation);
                }
                else
                {
                    ConversationManager.Instance.StartConversation(inJailConversation);
                }
            }
            else
            {
                ConversationManager.Instance.StartConversation(casualConversation);
            }
        });
    }

}
