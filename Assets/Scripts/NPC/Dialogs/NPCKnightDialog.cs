using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class NPCKnightDialog : NPCDialog
{
    public NPCConversation meetingConversation;
    public NPCConversation goingToTavernConversation;
    public NPCConversation Quest1Conversation;
    public NPCConversation summaryQuest1Conversation;
    public NPCConversation Quest2Conversation;
    public NPCConversation summaryQuest2Conversation;
    public NPCConversation Quest3Conversation;
    public NPCConversation summaryQuest3Conversation;

    public NPCConversation endQuestConversation;

    public NPCConversation inFrontOfSphynx;
    public NPCConversation awakeningPotion;

    public bool badGuy = false;

    private DecisionManager decisionManager;

    void Start()
    {
        decisionManager = FindObjectOfType<DecisionManager>();
    }

    private void OnMouseOver()
    {
        AddDialogCallback(() =>
        {
            if (!decisionManager.GetDecision(DecisionManager.Decision.AllerAuChateau))
            {
                if (!decisionManager.GetDecision(DecisionManager.Decision.RencontrerLesChevaliersDansLaPlaine))
                {
                    ConversationManager.Instance.StartConversation(meetingConversation);
                }
                else
                {
                    if (!decisionManager.GetDecision(DecisionManager.Decision.RencontrerLeTavernier))
                    {
                        ConversationManager.Instance.StartConversation(goingToTavernConversation);
                    }
                    else
                    {
                        if (!decisionManager.GetDecision(DecisionManager.Decision.AllerALaMontagneDuDesespoir))
                        {
                            if (decisionManager.GetDecision(DecisionManager.Decision.AccepterDeDevenirChevalier))
                            {
                                if (!decisionManager.GetDecision(DecisionManager.Decision.ReussirQuete1))
                                {
                                    if (badGuy)
                                    {
                                        if (!decisionManager.GetDecision(DecisionManager.Decision.DebuterQuete1))
                                        {
                                            ConversationManager.Instance.StartConversation(Quest1Conversation);
                                        }
                                        else
                                        {
                                            ConversationManager.Instance.StartConversation(summaryQuest1Conversation);
                                        }
                                    }
                                    else
                                    {
                                        if (!decisionManager.GetDecision(DecisionManager.Decision.RechercherQuete1))
                                        {
                                            ConversationManager.Instance.StartConversation(Quest1Conversation);
                                        }
                                        else
                                        {
                                            ConversationManager.Instance.StartConversation(summaryQuest1Conversation);
                                        }
                                    }
                                }
                                else 
                                {
                                    if (decisionManager.GetDecision(DecisionManager.Decision.AcheverQuete1) &&
                                        !decisionManager.GetDecision(DecisionManager.Decision.ReussirQuete2))
                                    {
                                        if (!decisionManager.GetDecision(DecisionManager.Decision.DebuterQuete2))
                                        {
                                            ConversationManager.Instance.StartConversation(Quest2Conversation);
                                        }
                                        else
                                        {
                                            ConversationManager.Instance.StartConversation(summaryQuest2Conversation);
                                        }
                                    }
                                    else
                                    {
                                        if (decisionManager.GetDecision(DecisionManager.Decision.AcheverQuete2) &&
                                            !decisionManager.GetDecision(DecisionManager.Decision.ReussirQuete3))
                                        {
                                            if (!decisionManager.GetDecision(DecisionManager.Decision.DebuterQuete3))
                                            {
                                                ConversationManager.Instance.StartConversation(Quest3Conversation);
                                            }
                                            else
                                            {
                                                ConversationManager.Instance.StartConversation(summaryQuest3Conversation);
                                            }
                                        }
                                        else
                                        {
                                            ConversationManager.Instance.StartConversation(endQuestConversation);
                                            ConversationManager.Instance.SetBool("Quest 2 succeded", decisionManager.GetDecision(DecisionManager.Decision.ReussirQuete2));
                                            ConversationManager.Instance.SetBool("Quest 3 succeded", decisionManager.GetDecision(DecisionManager.Decision.ReussirQuete3));
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (!decisionManager.GetDecision(DecisionManager.Decision.RencontrerSphynx))
                            {
                                ConversationManager.Instance.StartConversation(inFrontOfSphynx);
                            }
                            else
                            {
                                if (!decisionManager.GetDecision(DecisionManager.Decision.DecouvrirMechant))
                                {
                                    ConversationManager.Instance.StartConversation(awakeningPotion);
                                    ConversationManager.Instance.SetBool("Potion trouvée", decisionManager.GetDecision(DecisionManager.Decision.TrouverLaPotionDEveil));
                                    ConversationManager.Instance.SetBool("Potion bue", decisionManager.GetDecision(DecisionManager.Decision.BoireLaPotionDEveil));
                                    ConversationManager.Instance.SetBool("Trouver cube", decisionManager.GetDecision(DecisionManager.Decision.TrouverLeCube));
                                }
                            }
                        }
                    }
                }
            }
        });
    }
}
