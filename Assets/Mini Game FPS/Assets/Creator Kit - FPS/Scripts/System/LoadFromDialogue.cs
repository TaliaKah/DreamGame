using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections; // Nécessaire pour les coroutines

public class SceneLoader : MonoBehaviour
{
    public float delayInSeconds = 4f;
    
    public void LoadTutoSceneWithDelay()
    {
        StartCoroutine(LoadSceneAfterDelay());
    }
    private IEnumerator LoadSceneAfterDelay()
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene("Mini Game FPS/Assets/Creator Kit - FPS/Scenes/Tuto");
    }
}

