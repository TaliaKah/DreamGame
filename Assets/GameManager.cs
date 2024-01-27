using UnityEngine;
using DialogueEditor;
using System.Collections;

using UnityEngine.UI;

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
    public float delayBeforeLoad = 3f; 
    public Image fadeImage;
    public float fadeDuration = 1f;

    private void Update()
    {
        if (decisionManager.GetDecision(DecisionManager.Decision.SeReveiller))
        {
            StartCoroutine(LoadSceneWithDelay("Credits"));
        }
    }

    IEnumerator LoadSceneWithDelay(string sceneName)
    {
        // Fondu au noir
        StartCoroutine(FadeToBlack());

        // Attente
        yield return new WaitForSeconds(delayBeforeLoad);

        // Chargement de la scène
        SceneLoaderAsync.Instance.LoadScene(sceneName);
    }

    IEnumerator FadeToBlack()
    {
        float elapsedTime = 0f;
        Color originalColor = fadeImage.color;
        Color targetColor = Color.black;

        while (elapsedTime < fadeDuration)
        {
            fadeImage.color = Color.Lerp(originalColor, targetColor, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        fadeImage.color = targetColor;
    }
}
