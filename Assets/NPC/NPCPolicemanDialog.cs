using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class NPCPolicemanDialog : MonoBehaviour
{
    public NPCConversation casualConversation;
    public NPCConversation inJailConversation;
    public NPCConversation outofJailConversation;

    private DecisionManager decisionManager;

    void Start()
    {
        decisionManager = FindObjectOfType<DecisionManager>();
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (decisionManager.GetDecision(DecisionManager.Decision.AllerEnPrison))
            {
                if (decisionManager.GetDecision(DecisionManager.Decision.AllerALaMontagneDuDesespoir))
                {
                    ConversationManager.Instance.StartConversation(outofJailConversation);
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
        }
    }
    
}
