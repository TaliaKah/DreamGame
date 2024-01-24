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

    public string ToJSON() {
        return JsonUtility.ToJson(new Serialization<ItemClass>(items));
    }

    /**
     * <remarks>
     * This method overrides the current items stored with what is contained in the JSON.
     * </remarks>
     * 
     * <param name="rawJson">A JSON string representation of items stored</param>
     */
    public void FromJSON(string rawJson) {
        Serialization<ItemClass> data = JsonUtility.FromJson<Serialization<ItemClass>>(rawJson);
        items = data.ToList().FindAll(item => item != null);
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