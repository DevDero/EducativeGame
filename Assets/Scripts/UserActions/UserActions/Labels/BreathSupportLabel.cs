using TMPro;
using UnityEngine;
public class BreathSupportLabel : ActionLabel
{
    private BreathSupportAction breathSupportAction;
    public override UserAction Action { get { return breathSupportAction; } set { breathSupportAction = (BreathSupportAction)value; } }

    public override float CalculateScore()
    {
        int localPoints = 0;

        if (breathSupportAction.phoneConstraint)
        {
            breathSupportAction.CheckGoal();

            if (breathSupportAction.Repetition == 2)
            {
                localPoints += 2;
            }
            if (breathSupportAction.hasCPRValidated) localPoints++;
        }

        return localPoints;
    }

    public override void FillLabel()
    {
        score =
            ActionScore.value = CalculateScore();
        Repetition.text = breathSupportAction.Repetition.ToString();
    }
}