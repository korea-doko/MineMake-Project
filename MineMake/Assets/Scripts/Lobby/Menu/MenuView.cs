using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuView : MonoBehaviour
{
    public event EventHandler onMenuButtonClicked;
    public MenuPanel menuPanel;

    public void Init(MenuModel model)
    {
        menuPanel.Init();
        menuPanel.onMenuButtonClicked += MenuPanel_onMenuButtonClicked;
    }

    private void MenuPanel_onMenuButtonClicked(object sender, EventArgs e)
    {
        onMenuButtonClicked(sender, e);
    }
}
