using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    private SceneLoaderAsync Loader;

    public void Start() {
        Loader = SceneLoaderAsync.Instance;
        Debug.Log($"Loader {((Loader != null) ? "loaded" : "not loaded")}");
    }

    public void StartGame()
    {
        Debug.Log("Start clicked");
        Loader.LoadScene("SampleScene");
    }
}
