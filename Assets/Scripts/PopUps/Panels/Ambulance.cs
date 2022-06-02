using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;

public class Ambulance : PopUps
{
    [SerializeField] Animation anim;
    [SerializeField] TextMeshProUGUI timeTxt;

    const long _1Sec = 10000000;

    TimeSpan time = new TimeSpan(0, 0, 5), deltaTime = new TimeSpan(_1Sec);

    public override Action OnActivation { get => StartCountDown; }


    private void ShowTimer()
    {
        timeTxt.text = time.ToString(@"mm\:ss");
    }

    private void StartCountDown()
    {
        StartCoroutine(CountDown());
    }

    private IEnumerator CountDown()
    {
        while (time.Ticks > _1Sec )
        {
            while(GeneralManager.Instance.hasPaused)        //pause
            {

                yield return null;
            }

            time = time.Subtract(deltaTime);
            ShowTimer();
            yield return new WaitForSeconds(1);
        }
        PopUpManager.EndlevelPanel.panel.ActivatePanelWitchAction();
    }
     
}