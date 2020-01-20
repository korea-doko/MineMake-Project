using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPanelContainer : MonoBehaviour
{
    public List<ShopPanel> shopPanelList;
    public Transform shopPanelParent;

    public void Init()
    {
        RectTransform rect = this.GetComponent<RectTransform>();
        rect.offsetMax = Vector2.zero;
        rect.offsetMin = Vector2.zero;


        InitShopPanelList();

        Hide();
    }  
    private void InitShopPanelList()
    {
        shopPanelList = new List<ShopPanel>();

        GameObject shopPanelPrefab = Resources.Load("ShopPanel") as GameObject;

        for(int i = 0; i < 10;i++)
        {
            ShopPanel sp = ((GameObject)Instantiate(shopPanelPrefab)).GetComponent<ShopPanel>();
            sp.Init(i);

            sp.transform.SetParent(shopPanelParent);
            shopPanelList.Add(sp);
        }
    }

    public void Show(ShopModel model)
    {
        HideAllShopPanel();

        for(int i = 0; i < model.shopDataList.Count;i++)
        {
            ShopData sd = model.shopDataList[i];
            ShopPanel sp = shopPanelList[i];

            sp.Show(sd);
        }

        this.gameObject.SetActive(true);
    }
    public void Hide()
    {
        this.gameObject.SetActive(false);
    }

    private void HideAllShopPanel()
    {
        foreach (ShopPanel sp in shopPanelList)
            sp.Hide();
    }
}
