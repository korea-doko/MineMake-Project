using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopPanel : MonoBehaviour
{
    public int id;
    public TextMeshProUGUI testText;

    public void Init(int _id)
    {
        this.id = _id;

        Hide();
    }
    public void Show(ShopData _shopData)
    {
        testText.text = _shopData.itemData.itemName + "/비용 : "
            + _shopData.itemData.cost +
            "/공격력 : " + _shopData.itemData.power;

        this.gameObject.SetActive(true);
    }
    public void Hide()
    {
        this.gameObject.SetActive(false);
    }
}
