using TMPro;
using UnityEngine;

public class PhoneLabel : ActionLabel
{
    [SerializeField] private TextMeshProUGUI _Time;

    private PhoneAction phoneAction;
    public override UserAction Action { get { return phoneAction; } set { phoneAction = (PhoneAction)value; } }

    public override float CalculateScore()
    {
        return 1;
    }

    public override void FillLabel()
    {
        ActionScore.value = CalculateScore();
        _Time.text = ((int)Action.Duration).ToString();
    }
}