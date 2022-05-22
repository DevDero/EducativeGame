using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;

public class Ambulance : MonoBehaviour
{
    [SerializeField]Animation anim;
    [SerializeField] TextMeshProUGUI timeTxt;
    TimeSpan time = new TimeSpan(0, 3, 0), deltaTime = new TimeSpan(200000);

    public void ShowTimer()
    {
        timeTxt.text = time.ToString(@"mm\:ss");
    }
    public void CountDown()
    {
        if (time.Ticks > 200000)
            time = time.Subtract(deltaTime);
        else
            PopUpManager.Endlevel.AMCIK();
    }

    private void FixedUpdate()
    {
        CountDown();
        ShowTimer();
    }
}
