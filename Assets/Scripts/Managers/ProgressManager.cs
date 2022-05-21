using System;
using System.Collections;
using UnityEngine;

public class ProgressManager : MonoBehaviour
{
    public static ProgressManager Instance;
    public Patient patient;

    private void Awake()
    {
        Instance = this;
    }
    private void EndLevel()
    {
        patient.Stretcher();

    }
    public void ShowActionList()
    {

    }
}

public class AnalyseEvent
{


}
public class RewatchVideo : AnalyseEvent
{
    
}
public class PopQuiz : AnalyseEvent
{

}

