using System.Linq;
using UnityEngine;
using UnityEngine.UI;

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

