using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PJMovements : MonoBehaviour
{
    public GameObject prison;

    private void Awake() {
        Debug.Log("PJ Movement script loaded");
    }

    private void Start() {
        Debug.Log(SaveManager.Instance.LoadPosition);
        if (SaveManager.Instance.LoadOrder) {
            MainController.Instance.WarpAt(SaveManager.Instance.LoadPosition);
            transform.position = SaveManager.Instance.LoadPosition;
            SaveManager.Instance.Loaded();
            Debug.Log("Character warped to: " + SaveManager.Instance.LoadPosition);
        } else {
            Debug.Log("No load ordered.");
        }
    }
   
    public void GoingToJail()
    {
        transform.position = prison.transform.position;
        Debug.Log($"{transform.name} is going to jail");
    }
}
