﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        UIAudioPlayer.PlayPositive();
       //GameSystem.Instance.NextLevel();
       //SceneManager.LoadScene("Example Scene");
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
