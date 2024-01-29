using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SliderEffects : MonoBehaviour
{
    private GameManager controller = null;
    public Slider mouseSensitivitySlider;
    public Text minValueText;
    public Text maxValueText;

    private string previousSceneName = null;

    // Start is called before the first frame update
    void Start()
    {
        controller = GameManager.Instance;
        mouseSensitivitySlider.minValue = controller.MinSensitivity;
        mouseSensitivitySlider.maxValue = controller.MaxSensitivity;
        mouseSensitivitySlider.value = PlayerSettings.Instance.MouseSensitivity;
        minValueText.text = $"{controller.MinSensitivity}";
        maxValueText.text = $"{controller.MaxSensitivity}";

        previousSceneName = SceneManager.GetActiveScene().name;
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Options"));
    }

    public void Update()
    {
        if (Input.GetButtonDown("Cancel")) {
            SceneManager.UnloadSceneAsync("Options");
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(previousSceneName));
        }
    }

    public void UpdateSlider() {
        PlayerSettings.Instance.MouseSensitivity = mouseSensitivitySlider.value;
        // Debug.Log("Sensitivity changed to: " + mouseSensitivitySlider.value);
    }
}
