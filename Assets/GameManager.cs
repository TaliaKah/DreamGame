using UnityEngine;
using DialogueEditor;
using System.Collections;

using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public NPCConversation startConversation;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        if (ConversationManager.Instance != null && !DecisionTracker.Instance.Decisions[DecisionManager.Decision.MechantIntro])
        {
            ConversationManager.Instance.StartConversation(startConversation);
        }
    }
    public float delayBeforeLoad = 3f; 
    public Image fadeImage;
    public float fadeDuration = 1f;

    public void EndOfTheGame()
    {
        StartCoroutine(LoadSceneWithDelay("Credits"));
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
