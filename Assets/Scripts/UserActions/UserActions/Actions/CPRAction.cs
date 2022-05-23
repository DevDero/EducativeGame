using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CPRAction : UserAction
{
    public float sliderValue { get; set; }

    private CompressSens sens;

    private delegate void EmptyHandler();
    private event EmptyHandler EmptyEvent;

    float lastValue;

    private float posStart = 0.2f, posFin = 0.4f; 

    public List<HalfCompress> halfCompressesList = new List<HalfCompress>();

    public void StartCompressionCheck()
    {
        StartCoroutine(CompressCheck());
    }

    public IEnumerator CompressCheck()
    {

        HalfCompress compress = new HalfCompress();
        EmptyEvent += (() => ValidateCompress(compress));
        while (true)
        {
            if (sens == CompressSens.up)
            {
                compress.sens = CompressSens.up;
                if (sliderValue < posStart) 
                {
                    compress.isCompletePulse = true;
                }
                else
                {
                    compress.isCompletePulse = false;
                }
            }
            if (sens == CompressSens.down)
            {
                compress.sens = CompressSens.down;
                if (sliderValue > posFin) 
                {
                    compress.isCompletePulse = true;
                }
                else
                {
                    compress.isCompletePulse = false;
                }
            }
            yield return null;
        }
       
    }
         
    public void ValidateCompress(HalfCompress compress)
    {
        halfCompressesList.Add(compress);
    }

    public void GetCompressionSens()
    {
        if (lastValue == 0) lastValue = sliderValue;

        if (sliderValue > lastValue)        //SET UP
        {
            if (sens == CompressSens.up) if (EmptyEvent != null) EmptyEvent.Invoke();
            sens = CompressSens.down;
            lastValue = sliderValue;
        }
        if (sliderValue < lastValue)   //SET UP
        {
            if (sens == CompressSens.down) if (EmptyEvent != null) EmptyEvent.Invoke();
            sens = CompressSens.up;
            lastValue = sliderValue;
        }
    }

    public override void AddAction()
    {
        EmptyEvent = null;
        ActionList.UserActionList.Add(this);
        CheckGoal();
        halfCompressesList.Clear();
    }
    RangeInt hede = new RangeInt(25, 30);

    public override void CheckGoal()
    {
        int failedPulse=0;

        foreach (var item in halfCompressesList)
        {
            if (!item.isCompletePulse) failedPulse++;
        }
        if ( halfCompressesList.Count < 25 || halfCompressesList.Count > 35) PopUpManager.PopQuiz.LaunchPopQuiz("Count");
        if (failedPulse > 3) PopUpManager.Tip.ShowTip("Kollar kitli,kuvvetli, basıyı hareketi tamamlayarak gerçekleştir!",6);

    }
}
public class HalfCompress
{
    public float rpm;
    public CompressSens sens;
    public bool isCompletePulse { get; set; }
}
public enum CompressSens { up, down };
//"Kollar kitli,kuvvetli, basıyı hareketi tamamlayarak gerçekleştir!"
// PopUpManager.Tip.ShowTip("Doğru miktarda bası uyguladığından emin ol!", 4);
