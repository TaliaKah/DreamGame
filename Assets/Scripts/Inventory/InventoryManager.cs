using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    [SerializeField]private GameObject slotHolder;
    [SerializeField]private ItemClass itemToAdd;
    [SerializeField]private ItemClass itemToRemove;
    public List<ItemClass> Inventory = new List<ItemClass>();
    private GameObject[] slots;
    private string saveFilePath;

    public void Start()
    {
        slots = new GameObject[slotHolder.transform.childCount];
        // set all the slots in the array
        for (int i = 0; i < slotHolder.transform.childCount; i++)
        {
            slots[i] = slotHolder.transform.GetChild(i).gameObject;
        }
        
        
        
        RefreshUI();
        Add(itemToAdd);
        if (itemToRemove != null){
            Remove(itemToRemove);
            RefreshUI();
        }
        
    }

    public void RefreshUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            try
            {
                slots[i].transform.GetChild(0).GetComponent<Image>().enabled = true;
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = Inventory[i].itemIcon;
            }
            catch (System.Exception)
            {
                
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = null;
                slots[i].transform.GetChild(0).GetComponent<Image>().enabled = false;
            }
        }
    }

    public void Add(ItemClass item)
    {
        Inventory.Add(item);
        SaveInventory();
    }
    public void Remove(ItemClass item)
    {
        Inventory.Remove(item);
        SaveInventory();
    }

    private void Awake()
    {
        saveFilePath = Path.Combine(Application.persistentDataPath, "Inventory.json");
        LoadInventory();
    }

    public void SaveInventory()
    {
        string json = JsonUtility.ToJson(new Serialization<ItemClass>(Inventory));
        File.WriteAllText(saveFilePath, json);
        Debug.Log("Saving inventory to: " + saveFilePath);
    }

    public void LoadInventory()
    {
        if (File.Exists(saveFilePath)) {
            string json = File.ReadAllText(saveFilePath);
            Serialization<ItemClass> data = JsonUtility.FromJson<Serialization<ItemClass>>(json);
            Inventory = data.ToList();
        } else {
            Debug.LogWarning("Inventory file not found");
        }
    }

    [System.Serializable]
    private class Serialization<T> {
        [SerializeField]
        private List<T> target;
        public List<T> ToList() { return target; }

        public Serialization(List<T> target) {
            this.target = target;
        }
    }

}
