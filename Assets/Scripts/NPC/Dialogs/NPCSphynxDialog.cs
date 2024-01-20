using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class NPCSphynxDialog : MonoBehaviour
{
    public NPCConversation meetingConversation;

    private DecisionManager decisionManager;

    void Start()
    {
        decisionManager = FindObjectOfType<DecisionManager>();
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(!decisionManager.GetDecision(DecisionManager.Decision.RencontrerSphynx))
            {
                ConversationManager.Instance.StartConversation(meetingConversation);
                ConversationManager.Instance.SetBool("Recherche potion éveil", decisionManager.GetDecision(DecisionManager.Decision.RechercherLaPotionDEveil));
                ConversationManager.Instance.SetBool("Recherche cube", decisionManager.GetDecision(DecisionManager.Decision.AllerEnPrison));
            }
        }
    }
}