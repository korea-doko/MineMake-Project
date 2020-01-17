using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DepthView : MonoBehaviour
{
    public TextMeshProUGUI depthText;

    public void Init(DepthModel model)
    {
        ChangeDepthPanel(model.depth);
    }

    public void ChangeDepthPanel(int depth)
    {
        depthText.text = depth.ToString();
    }
}
