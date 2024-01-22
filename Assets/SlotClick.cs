using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotClick : MonoBehaviour
{
    public int slotIndex;
    public InventoryManager inventoryManager;
    public void OnMouseDown()
    {
        if (inventoryManager != null)
        {
            inventoryManager.OnItemClicked(slotIndex); // Call the method on InventoryManager when the slot is clicked
            Debug.Log($"Slot {slotIndex} was clicked.");
        }
    }
}
