using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    private static ShopManager inst;

    public static ShopManager Inst { get => inst;  }
    public ShopManager() { inst = this; }

    public ShopModel model;
    public ShopView view;


    private void Awake()
    {
        model.Init();
        view.Init(model);

        for (int i = 0; i < 5; i++)
            AddRandomItem();
    }

    private void AddRandomItem()
    {
        List<RawItemData> rids = DataManager.Inst.itemDataList;    
        int randIndex = UnityEngine.Random.Range(0, rids.Count);
        RawItemData rid = rids[randIndex];

        
        ItemData id = new ItemData(rid);

        ShopData sd = new ShopData(id);

        model.AddShopData(sd);
    }

    public void HideShop()
    {
        view.Hide();
    }

    public void ShowShop()
    {
        view.ShowShop(model);
    }
}
