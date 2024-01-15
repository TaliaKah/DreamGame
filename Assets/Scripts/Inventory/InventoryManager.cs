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
    }
    public void Remove(ItemClass item)
    {
        Inventory.Remove(item);
    }



}
