using System.Collections;
using UnityEngine;

//Abstract Class
[System.Serializable]
public abstract class ItemClass : ScriptableObject
{
    [Header("Item")]
    public string itemName;
    public Sprite itemIcon;
    public int itemID;
    public string itemDescription;
    public  abstract ItemClass GetItem();
    public  abstract ToolClass GetTool();
    public  abstract MiscClass GetMisc();
    public abstract ConsumableClass GetConsumable();
}
