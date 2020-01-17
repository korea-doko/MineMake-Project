using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeView : MonoBehaviour
{
    public TimeGauge timeGauge;

    public void Init(TimeModel model)
    {
        timeGauge.Init();
    }

    public void ChangeGaugeRatio(float ratio)
    {
        timeGauge.ChangeRatio(ratio);
    }
}
