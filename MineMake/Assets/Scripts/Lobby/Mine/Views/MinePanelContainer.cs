using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinePanelContainer : MonoBehaviour
{
    public event EventHandler onMinePanelClicked;

    public Transform minePanelParent;
    public List<MinePanel> minePanelList;

    
    public void Init()
    {
        RectTransform rect = this.GetComponent<RectTransform>();
        rect.offsetMax = Vector2.zero;
        rect.offsetMin = Vector2.zero;

        InitMinePanelList();
    }
  
    public void Show(MineModel model)
    {
        for(int i = 0; i < 10;i++)
        {
            MineData md = model.mineDataList[i];
            MinePanel mp = minePanelList[i];

            mp.Show(md);
        }

        this.gameObject.SetActive(true);
    }
    public void Hide()
    {
        this.gameObject.SetActive(false);
    }

    private void InitMinePanelList()
    {
        minePanelList = new List<MinePanel>();

        GameObject minePanelPrefab = Resources.Load("MinePanel") as GameObject;

        for (int i = 0; i < 10; i++)
        {
            MinePanel mp = ((GameObject)Instantiate(minePanelPrefab)).GetComponent<MinePanel>();

            mp.Init(i);
            mp.transform.SetParent(minePanelParent);

            mp.onPanelClicked += Mp_onPanelClicked;

            minePanelList.Add(mp);
        }
    }
    private void Mp_onPanelClicked(object sender, EventArgs e)
    {
        onMinePanelClicked(sender, e);
    }
}
