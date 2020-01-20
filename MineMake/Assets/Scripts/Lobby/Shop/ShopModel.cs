using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopModel : MonoBehaviour
{
    public List<ShopData> shopDataList;

    public void Init()
    {
        shopDataList = new List<ShopData>();
    }
    
    public void AddShopData(ShopData _data)
    {
        shopDataList.Add(_data);
    }
}
