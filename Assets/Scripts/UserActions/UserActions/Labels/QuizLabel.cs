using TMPro;
using UnityEngine;
public class QuizLabel : ActionLabel
{
    [SerializeField] private TextMeshProUGUI _Time;


    private QuizAction quizAction;
    public override UserAction Action { get { return quizAction; } set { quizAction = (QuizAction)value; } }

    public override float CalculateScore()
    {
        if (quizAction.result)
        {
            return curve.Evaluate(Action.Duration);
        }
        else
            return 0;
    }

    public override void FillLabel()
    {
        score =
        ActionScore.value = CalculateScore();
        _Time.text = ((int)Action.Duration).ToString();
    }
}