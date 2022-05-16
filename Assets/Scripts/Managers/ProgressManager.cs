using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

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

public class UserAction
{
    private Image image;
    protected bool isActionValidated;
    protected int repetition;
    
    protected virtual int RepetitionGoal { get; set; }

    public void IncrementRepetition()
    {
        if(ActionList.UserActionList.Count==0)
        {
            CheckGoal();
            ActionList.UserActionList.Add(this);
        }
        else
        {
            var analyser = ActionList.UserActionList.Last();
          
            if (analyser.GetType() == this.GetType())
            {
                analyser.repetition++;
                analyser.CheckGoal();
            }
            else
            {
                CheckGoal();
                ActionList.UserActionList.Add(this);
            }
        }
    }
    public virtual void CheckGoal()
    {

        Debug.Log(RepetitionGoal + "rep");
        Debug.Log(repetition + "rep");
        if (RepetitionGoal != repetition)
            Debug.Log("A goal not meet"); 
    }
}

public static class ActionList
{
    public enum ActionListResult {succes,failed,poused};
    public static List<UserAction> UserActionList = new List<UserAction>();
}

public class BreathSupportAction : UserAction
{
   
    protected override int RepetitionGoal { get => base.RepetitionGoal = 1;  }
}

public class CPRAction : UserAction
{

    public float posStart = 0.1f, posFin = 0.45f; 
    public float RPMmin=0.45f , RPMMax = 0.6f;

    
    public override void CheckGoal()
    {
        base.CheckGoal();
    }


}
public class ProgressionConstraints<TConstraint>
{
    public TConstraint constraint{get;set;}
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

