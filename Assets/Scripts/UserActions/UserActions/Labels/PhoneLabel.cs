using TMPro;
using UnityEngine;

public class PhoneLabel : ActionLabel
{
    [SerializeField] private TextMeshProUGUI _Time;

    private PhoneAction phoneAction;
    public override UserAction Action { get { return phoneAction; } set { phoneAction = (PhoneAction)value; } }

    public override float CalculateScore()
    {
        float midScore = 0;
        if (phoneAction.HasBreathChecked) midScore++;
        if (!phoneAction.UnnecessaryCPR) midScore++;
        midScore += curve.Evaluate(phoneAction.Duration);
        return midScore;
    }

    public override void FillLabel()
    {
        score=
        ActionScore.value = CalculateScore();
        _Time.text = ((int)Action.Duration).ToString();
    }
}