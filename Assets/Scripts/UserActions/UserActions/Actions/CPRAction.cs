using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CPRAction : UserAction
{
    #region ActionSpesific Fields

    public float sliderValue { get; set; }

    private bool automated=false;
    public bool Automated { get => automated;}

    private CompressSens sens;

    private delegate void EmptyHandler();
    private event EmptyHandler onCompression;
    
    private int failedPulse;
    private float lastValue;
    private float posStart = 0.2f, posFin = 0.4f;

    public List<HalfCompress> halfCompressesList = new List<HalfCompress>();

    #endregion

    #region ActionSpesificMethods
    public void StartCompressionCheck()
    {
        StartCoroutine(CompressCheck());
    }

    public IEnumerator CompressCheck()
    {

        HalfCompress compress = new HalfCompress();
        onCompression += (() => ValidateCompress(compress));
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
            if (sens == CompressSens.up) if (onCompression != null) onCompression.Invoke();
            sens = CompressSens.down;
            lastValue = sliderValue;
        }
        if (sliderValue < lastValue)   //SET UP
        {
            if (sens == CompressSens.down) if (onCompression != null) onCompression.Invoke();
            sens = CompressSens.up;
            lastValue = sliderValue;
        }
    }
    #endregion


    public override void AddAction()
    {
        onCompression = null;
        TransferCompressionData();
        base.AddAction();
        CheckGoal();
    }

    public void TransferCompressionData()                                   //TODO failedpulse can be mirrored here
    {
        foreach (var item in halfCompressesList)
        {
            if (!item.isCompletePulse) failedPulse++;
        }
        _Repetition = halfCompressesList.Count;
        halfCompressesList.Clear();
    }

    public override void CheckGoal()
    {
   
        if ( halfCompressesList.Count < 25 || halfCompressesList.Count > 35) PopUpManager.PopQuizPanel.LaunchPopQuiz("Count");
        if (failedPulse > 3) PopUpManager.TipPanel.ShowTip("Kollar kitli,kuvvetli, basıyı hareketi tamamlayarak gerçekleştir!",6);

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
