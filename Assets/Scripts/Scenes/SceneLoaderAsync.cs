// Source : https://myriadgamesstudio.com/how-to-use-the-unity-scenemanager/

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoaderAsync : MonoSingleton<SceneLoaderAsync> {

    // Loading Progress: private setter, public getter
    private float _loadingProgress;
    public float LoadingProgress { get { return _loadingProgress; } }
    public Text Text;

    public void LoadScene(string sceneName)
    {
        // kick-off the one co-routine to rule them all
        Debug.Log($"Load kicked-off: {sceneName}");
        StartCoroutine(LoadScenesInOrder(sceneName));
    }

    private IEnumerator LoadScenesInOrder(string sceneName)
    {
        // LoadSceneAsync() returns an AsyncOperation, 
        // so will only continue past this point when the Operation has finished
        // yield return SceneManager.LoadSceneAsync("Loading");
        
        // This works
        SceneManager.LoadScene("Loading");
        //Debug.Log($"Loading screen loaded.");
        //yield return new WaitForSeconds(2f);

        // as soon as we've finished loading the loading screen, start loading the game scene
        yield return StartCoroutine(LoadSceneWithProgress(sceneName));
    }

    private IEnumerator LoadSceneWithProgress(string sceneName)
    {
        var asyncScene = SceneManager.LoadSceneAsync(sceneName);

        Debug.Log($"Loading scene: {sceneName}...");

        // this value stops the scene from displaying when it's finished loading
        asyncScene.allowSceneActivation = false;

        while (!asyncScene.isDone)
        {
            // loading bar progress
            _loadingProgress = Mathf.Clamp01(asyncScene.progress / 0.9f) * 100;
            
            if (Text) {
                Text.text = $"Loading... {_loadingProgress}%";
            }

            // scene has loaded as much as possible, the last 10% can't be multi-threaded
            if (asyncScene.progress >= 0.9f)
            {
                // we finally show the scene
                asyncScene.allowSceneActivation = true;
            }

            yield return null;
        }

        Debug.Log($"Load complete: {sceneName}");
    }
}