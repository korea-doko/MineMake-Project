using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepthManager : MonoBehaviour
{
    private static DepthManager inst;

    public static DepthManager Inst { get => inst; }
    public DepthManager() { inst = this; }

    public DepthModel model;
    public DepthView view;

    private void Awake()
    {
        model.Init();
        view.Init(model);

        InputManager.Inst.onBGClicked += Inst_onBGClicked;
    }

  

    private void IncreaseDepth(int depth)
    {
        model.depth += depth;
        ChangeDepthPanel();
    }
    private void ChangeDepthPanel()
    {
        view.ChangeDepthPanel(model.depth);
    }


    private void Inst_onBGClicked(object sender, EventArgs e)
    {
        int depth = 1;
        IncreaseDepth(depth);
    }
}
