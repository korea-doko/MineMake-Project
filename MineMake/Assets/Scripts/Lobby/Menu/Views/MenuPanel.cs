using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPanel : MonoBehaviour
{
    public event EventHandler onMenuButtonClicked;
    public List<MenuButton> menuButtonList;

    public void Init()
    {
        menuButtonList = new List<MenuButton>();

        MenuButton[] mbs = this.GetComponentsInChildren<MenuButton>();

        foreach (MenuButton mb in mbs)
            menuButtonList.Add(mb);

        for(int i = 0; i < menuButtonList.Count; i++)
        {
            MenuButton mb = menuButtonList[i];
            EMenuType menuType = (EMenuType)i;
            mb.Init(menuType);
            mb.onButtonClicked += Mb_onButtonClicked;
        }


    }

    private void Mb_onButtonClicked(object sender, EventArgs e)
    {
        onMenuButtonClicked(sender, e);
    }
}
