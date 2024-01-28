using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryStash : MonoBehaviour {
    private static InventoryStash _instance;
    public static InventoryStash Instance => _instance;

    private List<ItemClass> items = new ();
    public List<ItemClass> Items => items;

    private void Awake() {
        if (_instance is null) {
            _instance = this;
        }
    }

    public void AddItem(ItemClass item) {
        if (item is null) {
            return;
        }
        items.Add(item);
    }

    public void RemoveItem(ItemClass item) {
        items.Remove(item);
    }
}