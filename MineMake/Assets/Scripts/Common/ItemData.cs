using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemData 
{
    public string itemName;
    public int cost;
    public int power;

    public ItemData (RawItemData _rid)
    {
        this.itemName = _rid.itemName;
        this.cost = _rid.cost;
        this.power = _rid.power;
    }
}
