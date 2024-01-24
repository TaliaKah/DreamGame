using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotClick : MonoBehaviour, IPointerClickHandler
{
    public int slotIndex;
    public InventoryManager inventoryManager;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (inventoryManager != null)
        {
            inventoryManager.OnItemClicked(slotIndex); // Call the method on InventoryManager when the slot is clicked
            Debug.Log($"Slot {slotIndex} was clicked.");
        }
    }
}
