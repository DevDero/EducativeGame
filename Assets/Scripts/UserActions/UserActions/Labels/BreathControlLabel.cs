using TMPro;
using UnityEngine;
public class BreathControlLabel : ActionLabel
{
    [SerializeField] private TextMeshProUGUI _Time;


    private BreathControlAction breathControl;
    public override UserAction Action { get { return breathControl; } set { breathControl = (BreathControlAction)value; } }

    public override float CalculateScore()
    {
       return curve.Evaluate(breathControl.DurationBeforeAction);
    }

    public override void FillLabel()
    {
        ActionScore.value = CalculateScore();
        _Time.text = ((int)breathControl.DurationBeforeAction).ToString();
    }
}