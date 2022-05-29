﻿using UnityEngine;
using UnityEngine.UI;

public class CprLabel : ActionLabel
{
    [SerializeField] private Image automatedOn, automatedOf;

    private CPRAction CPRaction;
    public override UserAction Action { get { return CPRaction; } set{ CPRaction = (CPRAction)value;}}


    public override void FillLabel()
    {
        ToggleAutomation(CPRaction.Automated);
        Repetition.text = CPRaction.Repetition.ToString();
        ActionScore.text = CPRaction.Score.ToString();
    }

    private void ToggleAutomation(bool isCPRAutomated)
    {
        automatedOn.enabled = isCPRAutomated;
        automatedOf.enabled = !isCPRAutomated;
    }
   

}
