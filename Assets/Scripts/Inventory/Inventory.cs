using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private InventoryStash stash;

    // Start is called before the first frame update
    void Start()
    {
        stash = InventoryStash.Instance;
    }

    void AddItem(ItemClass item) {
        stash.AddItem(item);
    }

    void RemoveItem(ItemClass item) {
        stash.RemoveItem(item);
    }
}
