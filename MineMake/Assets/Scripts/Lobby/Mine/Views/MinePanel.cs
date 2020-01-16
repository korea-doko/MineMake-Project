using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinePanel : MonoBehaviour
{
    public event EventHandler onPanelClicked;
    public int id;

    public void Init(int _id)
    {
        this.id = _id;
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(OnPanelClicked);

        Hide();
    } 

    public void Hide()
    {
        this.gameObject.SetActive(false);
    }

    public void Show(MineData md)
    {
        this.name = md.testData.ToString();

        this.gameObject.SetActive(true);
    }

    private void OnPanelClicked()
    {
        onPanelClicked(this, EventArgs.Empty);
    }
}
