using TMPro;
using UnityEngine;
public class BreathSupportLabel : ActionLabel
{
    private BreathSupportAction breathSupportAction;
    public override UserAction Action { get { return breathSupportAction; } set { breathSupportAction = (BreathSupportAction)value; } }


    public override void FillLabel()
    {
        ActionScore.text = breathSupportAction.Score.ToString();
        Repetition.text = breathSupportAction.Repetition.ToString();
    }
}