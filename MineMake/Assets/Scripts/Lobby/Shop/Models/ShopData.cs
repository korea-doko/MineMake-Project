using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class ShopData 
{
    public ItemData itemData;

    public ShopData(ItemData _id)
    {
        itemData = _id;
    }
}
