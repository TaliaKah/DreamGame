using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class NPCKingDialog : NPCDialog
{
    public NPCConversation outOfJailConversation;
    public NPCConversation finalConversation;
    public NPCConversation afterFightConversation;

    private DecisionManager decisionManager;

    void Start()
    {
        decisionManager = FindObjectOfType<DecisionManager>();
    }

    private void OnMouseOver()
    {
        AddDialogCallback(() =>
        {
            if (decisionManager.GetDecision(DecisionManager.Decision.AllerAuChateau))
            {
                if (!decisionManager.GetDecision(DecisionManager.Decision.TaperMechant))
                {
                    ConversationManager.Instance.StartConversation(finalConversation);
                    ConversationManager.Instance.SetBool("Verite", decisionManager.GetDecision(DecisionManager.Decision.TrouverLaFleurDeVerite));
                    ConversationManager.Instance.SetBool("Rebellion", decisionManager.GetDecision(DecisionManager.Decision.AccepterDeRejoindreLaRebellion));
                    ConversationManager.Instance.SetBool("Avoir cube", decisionManager.GetDecision(DecisionManager.Decision.TrouverLeCube));
                }
                else
                {

                    ConversationManager.Instance.StartConversation(afterFightConversation);
                }
            }
            else
            {
                if (decisionManager.GetDecision(DecisionManager.Decision.AllerEnPrison))
                {
                        ConversationManager.Instance.StartConversation(outOfJailConversation);
                }
            }
        });
    }
}
