using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GMButtons : MonoBehaviour
{
    private MainController controller = null;
    private SceneLoaderAsync loader;

    void Start()
    {
        controller = MainController.Instance;
        loader = SceneLoaderAsync.Instance;
        StartCoroutine(PrintCurrentScene());
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Game Menu"));
    }

    IEnumerator PrintCurrentScene()
    {
        while (true)
        {
            Debug.Log($"Current scene: {SceneManager.GetActiveScene().name}");
            yield return new WaitForSeconds(1.0f);
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            Debug.Log("Pressed cancel");
            Resume();
        }
    }

    private bool Active()
    {
        return SceneManager.GetActiveScene().name == "Game Menu";
    }

    public void Resume()
    {
        // TODO
        if (Active())
        {
            SceneManager.UnloadSceneAsync("Game Menu");
            controller.ResumeTheGame();
        }
    }

    public void ShowOptions()
    {
        // TODO
        if (Active()) {
            SceneManager.LoadScene("Options", LoadSceneMode.Additive);
        }
    }

    public void Save()
    {
        // TODO
        SaveManager.Instance.save();
    }

    public void Load()
    {
        // TODO
        if (SaveManager.Instance.load()) {
            MainController.Instance.WarpAt(SaveManager.Instance.LoadPosition);
            SaveManager.Instance.Loaded();
        }
    }

    public void MainMenu()
    {
        // TODO
        if (Active())
            loader.LoadScene("Main Menu");
    }
}
