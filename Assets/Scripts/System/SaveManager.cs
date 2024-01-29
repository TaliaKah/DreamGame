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

public static class VectorExtensions
{
    public static double[] ToDoubleArray(this Vector3 vector)
    {
        double[] result = new double[3];
        result[0] = vector.x;
        result[1] = vector.y;
        result[2] = vector.z;
        return result;
    }
}

public class SaveManager : MonoSingleton<SaveManager>
{
    private const string SAVE_PATH = "Save/JustASaveFile.json";

    private Vector3 characterLoadPosition;
    public Vector3 LoadPosition => characterLoadPosition;

    private InventoryStash inventoryStash = null;
    private DecisionTracker decisionTracker = null;

    private bool loadOrder = false;
    public bool LoadOrder => loadOrder;
    public void Loaded()
    {
        loadOrder = false;
    }

    public List<ItemClass> testInventory = new();

    private string tmp;

    void Start()
    {
        inventoryStash = InventoryStash.Instance;
        decisionTracker = DecisionTracker.Instance;
        // save();
        // load();

        try
        {
            if (!Directory.Exists(Path.Combine(Application.persistentDataPath, "Save")))
            {
                Directory.CreateDirectory(Path.Combine(Application.persistentDataPath, "Save"));
            }
        }
        catch (System.Exception ex)
        {
            Debug.Log("SaveManager: Couldn't create save directory: " + ex.Message);
        }
    }

    public void LinkPosition(Transform transform) {
        characterLoadPosition = transform.position;
    }

    public bool CanLoad()
    {
        return File.Exists(BuildSavePath());
    }

    private string BuildSavePath()
    {
        return Path.Combine(Application.persistentDataPath, SAVE_PATH);
    }

    public void ClearSave()
    {
        if (CanLoad())
        {
            File.Delete(BuildSavePath());
        }
    }

    public bool load()
    {
        // Load settings : with PlayerPrefs
        // https://docs.unity3d.com/ScriptReference/PlayerPrefs.html
        loadPrefs();

        if (!CanLoad())
        {
            Debug.Log($"Load attempted but no save file found.");
            return false;
        }

        string json;
        try
        {
            json = File.ReadAllText(BuildSavePath());
            Debug.Log($"Reading: {json}");
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Error loading save file: " + ex.Message);
            return false;
        }

        JsonData jsonData = JsonConvert.DeserializeObject<JsonData>(json);

        Debug.Log($"Inventory: {jsonData.Inventory.Count}");
        foreach (var item in jsonData.Inventory)
        {
            Debug.Log($"- {item}");
        }
        Debug.Log($"{jsonData.Position[0]}, {jsonData.Position[1]}, {jsonData.Position[2]}");
        foreach (var decision in jsonData.Decisions)
        {
            Debug.Log($"- {decision.Key}: {decision.Value}");
        }

        jsonData.Inventory.ForEach(i => inventoryStash.AddItem(i));
        characterLoadPosition = new Vector3((float)jsonData.Position[0], (float)jsonData.Position[1], (float)jsonData.Position[2]);
        decisionTracker.Decisions = jsonData.Decisions;

        loadOrder = true;
        return true;
    }

    public void test()
    {
        string json = @"{""key1"":""value1"",""key2"":""value2""}";

        Dictionary<string, string> values = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

        Debug.Log(values.Count);
        // 2

        Debug.Log(values["key1"]);
        // value1
    }

    public void save()
    {
        savePrefs();

        // Get all items needed
        // Vector3 position = controller.MainCamera.transform.position;
        JsonData jsonData = new();

        // Test data
        // Vector3 position = new Vector3(5, 3, 2);
        // Dictionary<DecisionManager.Decision, bool> tmpdecisions = new();
        // tmpdecisions[DecisionManager.Decision.RencontrerLesChevaliersDansLaPlaine] = false;

        jsonData.Inventory = testInventory;
        // jsonData.Inventory = inventoryStash.Items;
        jsonData.Position = characterLoadPosition.ToDoubleArray();
        jsonData.Decisions = decisionTracker.Decisions;

        string json = JsonConvert.SerializeObject(jsonData);
        Debug.Log(json);
        tmp = json;

        try
        {
            string path = BuildSavePath();
            Debug.Log("Saving game to: " + path);
            File.WriteAllText(path, json);
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Error saving game: " + ex.Message);
        }

        // string inventoryString = inventoryStash.ToJSON();
        // Debug.Log(inventoryString);
        // Dictionary<DecisionManager.Decision, bool> decisions = decisionTracker.Decisions;

        // // Save all other things
        // StringBuilder sb = new StringBuilder();
        // StringWriter sw = new StringWriter(sb);

        // using (JsonWriter writer = new JsonTextWriter(sw))
        // {
        //     writer.WriteStartObject();

        //     // Save inventory
        //     writer.WritePropertyName("inventory");
        //     writer.WriteRawValue(inventoryString);

        //     Debug.Log(sb);

        //     // Save position
        //     writer.WritePropertyName("position");
        //     writer.WriteStartArray();

        //     // TODO Replace with actual position
        //     Vector3 position = new Vector3(5, 3, 2);
        //     writer.WriteValue(position.x);
        //     writer.WriteValue(position.y);
        //     writer.WriteValue(position.z);
        //     writer.WriteEnd();

        //     // Save decisions
        //     writer.WritePropertyName("decisions");
        //     //writer.WriteRawValue(JsonConvert.SerializeObject(decisions));
        //     Dictionary<DecisionManager.Decision, bool> tmpdecisions = new();
        //     tmpdecisions[DecisionManager.Decision.RencontrerLesChevaliersDansLaPlaine] = false;
        //     writer.WriteRawValue(JsonConvert.SerializeObject(tmpdecisions));

        //     // Save current scene ?

        //     writer.WriteEndObject();

        //     Debug.Log(sb);
        //     tmp = sb.ToString();
        // }
    }

    private void loadPrefs()
    {
        PlayerSettings.Instance.MouseSensitivity = PlayerPrefs.GetFloat(Enum.GetName(typeof(SaveKeys), SaveKeys.MouseSensitivity));
    }

    private void savePrefs()
    {
        PlayerPrefs.SetFloat(Enum.GetName(typeof(SaveKeys), SaveKeys.MouseSensitivity), PlayerSettings.Instance.MouseSensitivity);
    }
}

// Define a class to represent the structure of your JSON data
public class JsonData
{
    [JsonProperty("inventory")]
    [JsonConverter(typeof(ItemClassListConverter))]
    public List<ItemClass> Inventory { get; set; }

    [JsonProperty("position")]
    public double[] Position { get; set; }

    [JsonProperty("decisions")]
    public Dictionary<DecisionManager.Decision, bool> Decisions { get; set; }
}

public class ItemClassListConverter : JsonConverter<List<ItemClass>>
{
    public override void WriteJson(JsonWriter writer, List<ItemClass> value, JsonSerializer serializer)
    {
        string json = JsonConvert.SerializeObject(value.ConvertAll(x => x.itemID).ToArray());
        Debug.Log(json);
        writer.WriteRawValue(json);
    }

    public override List<ItemClass> ReadJson(JsonReader reader, Type objectType, List<ItemClass> existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        if (reader.TokenType == JsonToken.StartArray)
        {
            // Move to the next token (inside the array)
            reader.Read();

            // Check if the array is empty
            if (reader.TokenType == JsonToken.EndArray)
            {
                return new List<ItemClass>();
            }

            // Use JsonUtility to deserialize the array
            List<ItemClass> items = new();

            do
            {
                items.Add(Resources.Load<ItemClass>("Items/Item_" + reader.Value));
            }
            while (reader.Read() && reader.TokenType != JsonToken.EndArray);

            // jsonArray = jsonArray.TrimEnd(',') + "]";
            // ItemClass[] itemsArray = JsonConvert.DeserializeObject<ItemClass[]>(jsonArray);
            // return new List<ItemClass>(itemsArray).FindAll(item => item != null);
            return items.FindAll(item => item != null);
        }

        return null;
    }

    [System.Serializable]
    private class Serialization<T>
    {
        [SerializeField]
        private List<T> target;
        public List<T> ToList() { return target; }

        public Serialization(List<T> target)
        {
            this.target = target;
        }
    }
}