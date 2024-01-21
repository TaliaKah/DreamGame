using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class NPCKingDialog : NPCDialog
{
    public NPCConversation inJailConversation;
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
        base.MouseOver(() =>
        {
            if (decisionManager.GetDecision(DecisionManager.Decision.AllerEnPrison))
            {
                if (decisionManager.GetDecision(DecisionManager.Decision.AllerALaMontagneDuDesespoir))
                {
                    ConversationManager.Instance.StartConversation(inJailConversation);
                }
                else
                {
                    ConversationManager.Instance.StartConversation(outOfJailConversation);
                }
            }
            else
            {
                if (!decisionManager.GetDecision(DecisionManager.Decision.BattreMechant))
                {
                    ConversationManager.Instance.StartConversation(finalConversation);
                    ConversationManager.Instance.SetBool("Avoir fleur de vérité", decisionManager.GetDecision(DecisionManager.Decision.TrouverLaFleurDeVerite));
                    ConversationManager.Instance.SetBool("Etre dans la rébellion", decisionManager.GetDecision(DecisionManager.Decision.AccepterDeRejoindreLaRebellion));
                    ConversationManager.Instance.SetBool("Avoir cube", decisionManager.GetDecision(DecisionManager.Decision.TrouverLeCube));
                    ConversationManager.Instance.SetBool("Avoir été en prison", decisionManager.GetDecision(DecisionManager.Decision.AllerEnPrison));
                }
                else
                {
                    ConversationManager.Instance.StartConversation(afterFightConversation);
                }
            }
        });
    }
}
