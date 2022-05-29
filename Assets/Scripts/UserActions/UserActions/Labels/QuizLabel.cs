﻿using TMPro;
using UnityEngine;
public class QuizLabel : ActionLabel
{
    [SerializeField] private TextMeshProUGUI _Time;


    private QuizAction quizAction;
    public override UserAction Action { get { return quizAction; } set { quizAction = (QuizAction)value; } }

    public override void FillLabel()
    {
        ActionScore.text = Action.Score.ToString();
        _Time.text = ((int)Action.Duration).ToString();
    }
}