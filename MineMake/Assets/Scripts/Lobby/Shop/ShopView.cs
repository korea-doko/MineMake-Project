using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopView : MonoBehaviour
{
    public ShopPanelContainer shopPanelContainer;

    public void Init(ShopModel model)
    {
        shopPanelContainer.Init();
    }

    public void ShowShop(ShopModel model)
    {
        shopPanelContainer.Show(model);
    }

    public void Hide()
    {
        shopPanelContainer.Hide();
    }
}
