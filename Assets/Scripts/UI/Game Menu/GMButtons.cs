using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GMButtons : MonoBehaviour
{
    private Controller controller = null;
    private SceneLoaderAsync loader;

    void Start()
    {
        controller = Controller.Instance;
        loader = SceneLoaderAsync.Instance;
    }

    public void Update() {
        if (Input.GetButtonDown("Cancel")) {
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            Debug.Log("Pressed cancel");
            Resume();
        }
    }

    public void Resume()
    {
        // TODO
        SceneManager.UnloadSceneAsync("Game Menu");
        controller.ResumeTheGame();
    }

    public void ShowOptions()
    {
        // TODO
        SceneManager.LoadScene("Options", LoadSceneMode.Additive);
    }

    public void Save()
    {
        // TODO
    }

    public void Load()
    {
        // TODO
    }

    public void MainMenu()
    {
        // TODO
        loader.LoadScene("Main Menu");
    }
}
