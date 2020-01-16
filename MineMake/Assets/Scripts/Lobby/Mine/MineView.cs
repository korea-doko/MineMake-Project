using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineView : MonoBehaviour
{
    public event EventHandler onMinePanelClicked;

    public MinePanelContainer minePanelContainer;

    public void Init(MineModel model)
    {
        minePanelContainer.Init();

        minePanelContainer.onMinePanelClicked += MinePanelContainer_onMinePanelClicked;
        
    }

    

    public void ShowMine(MineModel model)
    {
        minePanelContainer.Show(model);
    }

    private void MinePanelContainer_onMinePanelClicked(object sender, EventArgs e)
    {
        onMinePanelClicked(sender, e);
    }
}
