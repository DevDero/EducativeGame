using System;
using System.Collections;
using UnityEngine;

public class ProgressManager : MonoBehaviour
{
    public static ProgressManager Instance;

    private void Awake()
    {
        Instance = this;
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

