using UnityEngine;
using DialogueEditor;

public class GameManager : MonoBehaviour
{
    public NPCConversation startConversation;

    void Start()
    {
        // Assurez-vous que cet objet persiste entre les scènes
        DontDestroyOnLoad(gameObject);

        // Lancez la conversation au moment approprié
        if (ConversationManager.Instance != null)
        {
            ConversationManager.Instance.StartConversation(startConversation);
        }
    }
}
