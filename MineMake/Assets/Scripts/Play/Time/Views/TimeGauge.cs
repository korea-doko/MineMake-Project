using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeGauge : MonoBehaviour
{
    public Image gaugeImage;

    public void Init()
    {
        this.gaugeImage = this.GetComponent<Image>();

    }

    public void ChangeRatio(float ratio)
    {
        this.gaugeImage.fillAmount = ratio;
    }
}
