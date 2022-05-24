using UnityEngine;
using UnityEngine.UI;

public class CprLabel : ActionLabel
{
    [SerializeField] Image automatedOn, automatedOf;

    public void FillLabel(string repetition, string score,bool isAutomated)
    {
        base.FillLabel(repetition, score);

        automatedOn.enabled = isAutomated;
        automatedOf.enabled = !isAutomated;

    }

}
