using TMPro;
using UnityEngine;
public class BreathControlLabel : ActionLabel
{
    [SerializeField] private TextMeshProUGUI _Time;


    private BreathControlAction breathControl;
    public override UserAction Action { get { return breathControl; } set { breathControl = (BreathControlAction)value; } }

    public override float CalculateScore()
    {
        throw new System.NotImplementedException();
    }

    public override void FillLabel()
    {
        ActionScore.value=breathControl.Score;
        _Time.text = ((int)Action.Duration).ToString();
    }
}