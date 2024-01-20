using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class NPCFairyDialog : MonoBehaviour
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
        if(decisionManager != null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (!decisionManager.GetDecision(DecisionManager.Decision.RencontrerLesChevaliersDansLaPlaine))
                {
                    ConversationManager.Instance.StartConversation(meetingConversation);
                }
                else
                {
                if (!decisionManager.GetDecision(DecisionManager.Decision.AllerAuChateau))
                    {
                        ConversationManager.Instance.StartConversation(casualConversation);
                        ConversationManager.Instance.SetBool("AccepteRebellion", decisionManager.GetDecision(DecisionManager.Decision.AccepterDeRejoindreLaRebellion));
                        ConversationManager.Instance.SetBool("RefusRebellion", decisionManager.GetDecision(DecisionManager.Decision.RefuserDeRejoindreLaRebellion));
                    }
                }
            }
        }
    }
}
