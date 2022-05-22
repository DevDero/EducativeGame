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
    //private float RPMmin=0.45f , RPMMax = 0.6f;

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

    public void PrintLast2Elements()
    {
        if (halfCompressesList.Count > 1)
        {
            Debug.Log("Total: "+halfCompressesList.Count +" "+
               "N: " + halfCompressesList[halfCompressesList.Count - 1].isCompletePulse + "  "
         + "N-1: " + halfCompressesList[halfCompressesList.Count - 2].isCompletePulse);
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
        PrintLast2Elements();
    }

    public override void AddAction()
    {
        EmptyEvent = null;
        CheckGoal();
        ActionList.UserActionList.Add(this);
        halfCompressesList.Clear();
    }
    public override void CheckGoal()
    {
        int failedPulse=0;

        foreach (var item in halfCompressesList)
        {
            if (!item.isCompletePulse) failedPulse++;
        }
        if (failedPulse > 3) PulseStyleTip();
        if (halfCompressesList.Count < 25 || halfCompressesList.Count > 35) PopUpManager.PopQuiz.LaunchPopQuiz("Count");
    }
    public void PulseStyleTip()
    {
        PopUpManager.Tip.ShowTip("Kollar kitli,kuvvetli, basıyı hareketi tamamlayarak gerçekleştir!",6);
    }
    public void PulseAmountTip()
    {
        PopUpManager.Tip.ShowTip("Doğru miktarda bası uyguladığından emin ol!", 4);
    }
    public override void CreateLabel(Transform content)
    {
        base.CreateLabel(content);
        GameObject.Instantiate<GameObject>(label, content);
    }
}
public class HalfCompress
{
    public float rpm;
    public CompressSens sens;
    public bool isCompletePulse { get; set; }
}

public enum CompressSens { up, down };
