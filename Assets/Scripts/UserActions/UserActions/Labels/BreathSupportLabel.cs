using TMPro;
using UnityEngine;
public class BreathSupportLabel : ActionLabel
{
    private BreathSupportAction breathSupportAction;
    public override UserAction Action { get { return breathSupportAction; } set { breathSupportAction = (BreathSupportAction)value; } }

    public override float CalculateScore()
    {
        throw new System.NotImplementedException();
    }

    public override void FillLabel()
    {
        ActionScore.value = breathSupportAction.Score;
        Repetition.text = breathSupportAction.Repetition.ToString();
    }
}