using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum CompressSens { up, down };

public class CPRAction : UserAction
{
    public float sliderValue { get; set; }

    private CompressSens sens;

    private delegate void EmptyHandler();
    private event EmptyHandler EmptyEvent;

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
        Debug.Log("HEDE");

        while (true)
        {
            if (sens == CompressSens.up)
            {
                compress.sens = CompressSens.up;
                if (sliderValue < posStart) 
                {
                    Debug.Log("trued up");
                    compress.isCompletePulse = true;
                }
                else
                {
                    compress.isCompletePulse = false;
                    Debug.Log("falsed up");
                }
            }
            if (sens == CompressSens.down)
            {
                compress.sens = CompressSens.down;
                if (sliderValue > posFin) 
                {
                    Debug.Log("trued down" );
                    compress.isCompletePulse = true;
                }
                else
                {
                    compress.isCompletePulse = false;
                    Debug.Log("falsed down");
                }
            }
            yield return null;
        }
       
    }

    public void PrintLast2Elements()
    {
        if (halfCompressesList.Count > 1)
        {
            Debug.Log(
               "N: " + halfCompressesList[halfCompressesList.Count - 1].isCompletePulse + "  "
         + "N-1: " + halfCompressesList[halfCompressesList.Count - 2].isCompletePulse);
        }
    }
         
    public void ValidateCompress(HalfCompress compress)
    {
        Debug.Log(compress.sens);
        halfCompressesList.Add(compress);
    }

    float lastValue;
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
}
public class HalfCompress
{
    public bool completeDone;
    public CompressSens sens;
    public bool isCompletePulse { get; set; }
    
}
