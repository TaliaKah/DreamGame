using System.Collections;
using UnityEngine;

//Abstract Class
public abstract class ItemClass : ScriptableObject
{
    [Header("Item")]
    public string itemName;
    public Sprite itemIcon;
    public int itemID;

    public  abstract ItemClass GetItem();
    public  abstract ToolClass GetTool();
    public  abstract MiscClass GetMisc();
    public abstract ConsumableClass GetConsumable();
}
