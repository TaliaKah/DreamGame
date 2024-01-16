using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class NPCFairyDialog : MonoBehaviour
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
                if (!decisionManager.GetDecision(DecisionManager.Decision.AccepterDeRejoindreLaRebellion)
                && !decisionManager.GetDecision(DecisionManager.Decision.RefuserDeRejoindreLaRebellion))
                {
                    ConversationManager.Instance.StartConversation(firstConversation);
                    }
                else
                {
                    ConversationManager.Instance.StartConversation(casualConversation);
                    ConversationManager.Instance.SetBool("AccepteRebellion", decisionManager.GetDecision(DecisionManager.Decision.AccepterDeRejoindreLaRebellion));
                    ConversationManager.Instance.SetBool("RefusRebellion", decisionManager.GetDecision(DecisionManager.Decision.RefuserDeRejoindreLaRebellion));
                }
            }
        }
    }
}
