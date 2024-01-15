using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    private SceneLoaderAsync Loader;

    public void Start() {
        Loader = gameObject.AddComponent(typeof(SceneLoaderAsync)) as SceneLoaderAsync;
        Debug.Log($"Loader {((Loader) ? "loaded" : "not loaded")}");
    }

    public void StartGame()
    {
        Debug.Log("Start clicked");
        Loader.LoadScene("SampleScene");
    }
}
