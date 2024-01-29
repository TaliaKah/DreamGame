using UnityEngine;
using DialogueEditor;
using System.Collections;

using UnityEngine.UI;

public class GameManager : MonoSingleton<GameManager>
{
    public NPCConversation startConversation;
    private bool m_IsPaused = false;
    private bool m_IsInConversation = false;
    public bool IsInConversation => m_IsInConversation;

    #region Settings
    public readonly float MinSensitivity = 0.0f;
    public readonly float MaxSensitivity = 100.0f;
    #endregion

    void Start()
    {
        if (ConversationManager.Instance != null && !DecisionTracker.Instance.Decisions[DecisionManager.Decision.MechantIntro])
        {
            ConversationManager.Instance.StartConversation(startConversation);
        }

        SetPauseFlags();
    }

    public bool IsUpdatable()
    {
        return !m_IsPaused && !m_IsInConversation;
    }

    public void SetPauseFlags()
    {
        bool display = m_IsPaused | m_IsInConversation;
        Cursor.lockState = display ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = display;
    }

    public void SetConversationMode(bool value)
    {
        m_IsInConversation = value;
        SetPauseFlags();
    }

    public void PauseTheGame()
    {
        m_IsPaused = true;
        SetPauseFlags();
    }

    public void ResetStates() {
        m_IsPaused = false;
        m_IsInConversation = false;
    }

    public void DisplayCursor() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
    }

    public void ResumeTheGame()
    {
        m_IsPaused = false;
        SetPauseFlags();
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

        ResetStates();
        DisplayCursor();

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
