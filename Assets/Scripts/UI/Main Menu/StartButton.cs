using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    public void StartGame()
    {
        Debug.Log("Start clicked");
        SceneLoaderAsync loader = SceneLoaderAsync.Instance;
        Debug.Log(SaveManager.Instance);
        Debug.Log(loader);
        loader.LoadScene("SampleScene");
    }
}
