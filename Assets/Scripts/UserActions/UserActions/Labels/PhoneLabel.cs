﻿using TMPro;
using UnityEngine;

public class PhoneLabel : ActionLabel
{
    [SerializeField] private TextMeshProUGUI _Time;

    private PhoneAction phoneAction;
    public override UserAction Action { get { return phoneAction; } set { phoneAction = (PhoneAction)value; } }

    public override void FillLabel()
    {
        ActionScore.text = Action.Score.ToString();
        _Time.text = ((int)Action.Duration).ToString();
    }
}