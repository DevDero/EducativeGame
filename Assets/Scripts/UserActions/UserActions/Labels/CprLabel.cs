using UnityEngine;
using UnityEngine.UI;

public class CprLabel : ActionLabel
{
    [SerializeField] private Image automatedOn, automatedOf;

    private CPRAction CPRaction;
    public override UserAction Action { get { return CPRaction; } set{ CPRaction = (CPRAction)value;}}

 
    public override float CalculateScore()
    {
        float localPoint = 0;
        int fail = CPRaction.FailedPulse;
        if (fail < 8) localPoint++;
        localPoint += curve.Evaluate(CPRaction.Repetition);
        return localPoint;
    }

    public override void FillLabel()
    {
        ToggleAutomation(CPRaction.Automated);
        Repetition.text = CPRaction.Repetition.ToString();
        score =
            ActionScore.value = CalculateScore();
    }

    private void ToggleAutomation(bool isCPRAutomated)
    {
        automatedOn.enabled = isCPRAutomated;
        automatedOf.enabled = !isCPRAutomated;
    }
   

}
