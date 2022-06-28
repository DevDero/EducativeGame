using TMPro;
using UnityEngine;
public class BreathSupportLabel : ActionLabel
{
    private BreathSupportAction breathSupportAction;
    public override UserAction Action { get { return breathSupportAction; } set { breathSupportAction = (BreathSupportAction)value; } }

    public override float CalculateScore()
    {
        int localPoints = 0;
        breathSupportAction.CheckGoal();
        //if (cPRAction.Repetition > 25 && cPRAction.Repetition < 35) 
        //{
        //    localPoints++;
        //}
        //if (breathSupportAction.Repetition == 2) 
        //{
        //    localPoints += 2;
        //}
        return localPoints;
    }

    public override void FillLabel()
    {
        ActionScore.value = CalculateScore();
        Repetition.text = breathSupportAction.Repetition.ToString();
    }
}