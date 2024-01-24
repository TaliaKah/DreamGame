using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public enum SaveKeys
{
    MouseSensitivity
}

public class SaveManager : MonoBehaviour
{
    private static SaveManager instance;
    public static SaveManager Instance
    {
        get; private set;
    }

    private Controller controller = null;
    private InventoryStash inventoryStash = null;
    private DecisionTracker decisionTracker = null;

    void Start()
    {
        controller = Controller.Instance;
        inventoryStash = InventoryStash.Instance;
        decisionTracker = DecisionTracker.Instance;

        save();
    }

    public void load()
    {
        // Load settings : with PlayerPrefs
        // https://docs.unity3d.com/ScriptReference/PlayerPrefs.html
        loadPrefs();

        // Load position

        // Load current scene

        // Load current progress

        // Load inventory
    }

    public void test() {
        string json = @"{""key1"":""value1"",""key2"":""value2""}";

        Dictionary<string, string> values = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

        Debug.Log(values.Count);
        // 2

        Debug.Log(values["key1"]);
        // value1
    }

    public void save()
    {
        // savePrefs();

        // Get all items needed
        // Vector3 position = controller.MainCamera.transform.position;
        string inventoryString = inventoryStash.ToJSON();
        Debug.Log(inventoryString);
        Dictionary<DecisionManager.Decision, bool> decisions = decisionTracker.Decisions;

        // Save all other things
        StringBuilder sb = new StringBuilder();
        StringWriter sw = new StringWriter(sb);

        using (JsonWriter writer = new JsonTextWriter(sw))
        {
            writer.WriteStartObject();

            // Save inventory
            writer.WritePropertyName("inventory");
            writer.WriteRawValue(inventoryString);

            Debug.Log(sb);

            // Save position
            writer.WritePropertyName("position");
            writer.WriteStartArray();
            Vector3 position = new Vector3(5, 3, 2);
            writer.WriteValue(position.x);
            writer.WriteValue(position.y);
            writer.WriteValue(position.z);
            writer.WriteEnd();

            // Save decisions
            writer.WritePropertyName("decisions");
            writer.WriteRawValue(JsonConvert.SerializeObject(decisions));

            // Save current scene

            // Save current progress

            writer.WriteEndObject();

            Debug.Log(sb);
        }
    }

    private void loadPrefs()
    {
        controller.MouseSensitivity = PlayerPrefs.GetFloat(Enum.GetName(typeof(SaveKeys),SaveKeys.MouseSensitivity));
    }

    private void savePrefs()
    {
        PlayerPrefs.SetFloat(Enum.GetName(typeof(SaveKeys), SaveKeys.MouseSensitivity), controller.MouseSensitivity);
    }
}