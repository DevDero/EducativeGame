using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CompressSens { up, down };

public class CPRAction : UserAction
{
    public float sliderValue { get; set; }

    private CompressSens sens;

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
        bool halfComplete = false;
        while (true)
        {
            while (sens == CompressSens.up)
            {
                if (sliderValue < posStart) 
                {
                    Debug.Log("trued up");
                    halfComplete = true;
                }
                else
                {
                    halfComplete = false;
                    Debug.Log("falsed up");
                }
                yield return null;
            }
            compress.isCompletePulse = halfComplete;
            halfCompressesList.Add(compress);

            while (sens == CompressSens.down)
            {
                if (sliderValue > posFin) 
                {
                    Debug.Log("trued down" );
                    halfComplete = true;
                }
                else
                {
                    halfComplete = false;
                    Debug.Log("falsed down");
                }
                yield return null;
            }
            compress.isCompletePulse = halfComplete;
            halfCompressesList.Add(compress);

            Debug.Log(halfCompressesList.Count);
            yield return null;
        }
       
    }

    float lastValue;
    public void GetCompressionSens()
    {
        if (lastValue == 0) lastValue = sliderValue;

        if (sliderValue > lastValue)
        {
            sens = CompressSens.down;
            lastValue = sliderValue;
        }
        else if (sliderValue < lastValue)
        {
            sens = CompressSens.up;
            lastValue = sliderValue;
        }
    }
}
public class HalfCompress
{
    public bool completeDone;
    public CompressSens sens;
    public bool isCompletePulse { get; set; }
    
}
