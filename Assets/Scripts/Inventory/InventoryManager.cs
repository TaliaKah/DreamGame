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
    [SerializeField]private InventoryDescription itemDescription;
    private InventoryStash stash;
    private GameObject[] slots;
    private string saveFilePath;

    public void Start()
    {
        stash = InventoryStash.Instance;

        slots = new GameObject[slotHolder.transform.childCount];
        // set all the slots in the array
        for (int i = 0; i < slotHolder.transform.childCount; i++)
        {
            slots[i] = slotHolder.transform.GetChild(i).gameObject;
        }
        
        
        RefreshUI();
        itemDescription.RefreshDescription();
        DebugInventoryTest();
        
        SetupInventorySlots();
    }

    public void DebugInventoryTest() {
        if (itemToRemove != null && itemToAdd != null)
        {
            Add(itemToAdd);
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
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = stash.Items[i].itemIcon;
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
        if(item != null)
        {
            stash.AddItem(item);
            // SaveInventory();
        }
    }
    public void Remove(ItemClass item)
    {
        if(item != null)
        {
            stash.RemoveItem(item);
            // SaveInventory();
        }
    }

    private void Awake()
    {
        saveFilePath = Path.Combine(Application.persistentDataPath, "Inventory.json");
        // LoadInventory();
    }

    // public void SaveInventory()
    // {
    //     try
    //     {
    //         string json = stash.ToJSON();
    //         File.WriteAllText(saveFilePath, json);
    //         Debug.Log("Saving inventory to: " + saveFilePath);
    //     }
    //     catch (System.Exception ex)
    //     {
    //         Debug.LogError("Error saving inventory: " + ex.Message);
    //     }
    // }

    // public void LoadInventory()
    // {
    //     try
    //     {
    //         if (File.Exists(saveFilePath))
    //         {
    //             string json = File.ReadAllText(saveFilePath);
    //             stash.FromJSON(json);
                
    //             // Filter out null items after load
    //             Debug.Log("Loaded inventory from: " + saveFilePath);
    //         }
    //         else
    //         {
    //             Debug.LogWarning("Inventory file not found at: " + saveFilePath);
    //         }
    //     }
    //     catch (System.Exception ex)
    //     {
    //         Debug.LogError("Error loading inventory: " + ex.Message);
    //     }
    // }

    public void OnItemClicked(int itemIndex)
    {
        if (itemIndex < 0 || itemIndex >= stash.Items.Count) return;

        ItemClass item = stash.Items[itemIndex];
        if (item != null)
        {
            // Update the description panel
            itemDescription.SetDescription(item);
        }
    }

    public void SetupInventorySlots()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            int index = i;  // Local copy for the closure below
            slots[i].GetComponent<SlotClick>().slotIndex = index;
        }
    }
}
