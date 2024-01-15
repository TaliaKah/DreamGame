using System.Collections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class NPCKnightDialog : MonoBehaviour
{
    public NPCConversation firstConversation;
    public NPCConversation secondConversation;

    public NPCConversation QuestConversation1;
    public NPCConversation casualQuestConversation1;
    public NPCConversation QuestConversation2;
    public NPCConversation casualQuestConversation2;
    public NPCConversation QuestConversation3;
    public NPCConversation casualQuestConversation3;

    public NPCConversation endQuestConversation;

    private DecisionManager decisionManager;
    // ajouter conversattion qui invite à prendre un verre dans la taverne et à parler au tavernier

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
                    ConversationManager.Instance.StartConversation(firstConversation);
                }
                else
                {
                    ConversationManager.Instance.StartConversation(secondConversation);
                    ConversationManager.Instance.SetBool("EtreChevalier", decisionManager.GetDecision(DecisionManager.Decision.AccepterDeDevenirChevalier));
                }
            }
        }
    }
    
}
