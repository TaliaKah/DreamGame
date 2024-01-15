using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class NPCTavernDialog : MonoBehaviour
{
    public NPCConversation firstConversation;
    public NPCConversation casualConversation;
    private DecisionManager decisionManager;

    void Start()
    {
        decisionManager = FindObjectOfType<DecisionManager>();
    }

    private void OnMouseOver()
    {
        if(decisionManager != null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (!decisionManager.GetDecision(DecisionManager.Decision.PrendreUneBoissonALaTaverne))
                {
                    ConversationManager.Instance.StartConversation(casualConversation);
                }
                else
                {
                    ConversationManager.Instance.StartConversation(firstConversation);
                    ConversationManager.Instance.SetBool("EtreChevalier", decisionManager.GetDecision(DecisionManager.Decision.AccepterDeDevenirChevalier));
                }
            }
        }
    }
    
}
