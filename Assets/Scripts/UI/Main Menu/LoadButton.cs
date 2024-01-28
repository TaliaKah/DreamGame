using UnityEngine;

public class LoadButton : MonoBehaviour
{
    public void LoadGame()
    {
        if (SaveManager.Instance.load()) {
            Debug.Log((SaveManager.Instance.LoadOrder) ? "Load ordered" : "Load not ordered");
            SceneLoaderAsync.Instance.LoadScene("SampleScene");
        } else {
            Debug.Log("Game load attempted in Main Menu.");
        }
    }
}