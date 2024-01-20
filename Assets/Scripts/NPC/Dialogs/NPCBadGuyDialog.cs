using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class NPCBadGuyDialog : MonoBehaviour
{
    public NPCConversation fightConversation;

    private DecisionManager decisionManager;

    void Start()
    {
        decisionManager = FindObjectOfType<DecisionManager>();
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!decisionManager.GetDecision(DecisionManager.Decision.TaperMechant))
            {
                ConversationManager.Instance.StartConversation(fightConversation);
            }
        }
    }
    
}