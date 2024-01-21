using UnityEngine;
using DialogueEditor;

public class GameManager : MonoBehaviour
{
    public NPCConversation startConversation;

    private DecisionManager decisionManager;

    void Start()
    {
        decisionManager = FindObjectOfType<DecisionManager>();
        DontDestroyOnLoad(gameObject);
        if (ConversationManager.Instance != null)
        {
            ConversationManager.Instance.StartConversation(startConversation);
        }
    }

    private void Update()
    {
        if (decisionManager.GetDecision(DecisionManager.Decision.SeReveiller))
        {
            SceneLoaderAsync.Instance.LoadScene("Credits");
        }
    }
}
