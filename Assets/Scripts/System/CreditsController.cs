using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class CreditsController : MonoBehaviour
{
    public float timeBeforeMainMenu = 10f;

    void Start()
    {
        StartCoroutine(ReturnToMainMenuAfterDelay());
    }

    IEnumerator ReturnToMainMenuAfterDelay()
    {
        Debug.Log("Avant d'attendre le délai.");
        yield return new WaitForSeconds(timeBeforeMainMenu);
        Debug.Log("Après avoir attendu le délai. Chargement de la scène Main Menu.");
        SceneManager.LoadScene("Main Menu");
    }
}
