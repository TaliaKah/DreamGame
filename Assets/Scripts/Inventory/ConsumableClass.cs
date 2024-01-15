using System.Collections;
using UnityEngine;
[CreateAssetMenu(fileName = "New Tool", menuName = "Item/Consumable")]

public class ConsumableClass : ItemClass
{
    //data specific to consumable items
    [Header("Consumable")]
    public float healthAdded;

    public override ItemClass GetItem(){ return this; }
    public override ToolClass GetTool(){ return null; }
    public override MiscClass GetMisc(){ return null; }
    public override ConsumableClass GetConsumable(){ return this; }
}
