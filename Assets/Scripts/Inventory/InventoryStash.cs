using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryStash : MonoSingleton<InventoryStash> {

    private List<ItemClass> items = new ();
    public List<ItemClass> Items => items;

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