using TMPro;
using UnityEngine;
public class QuizLabel : ActionLabel
{
    [SerializeField]TextMeshProUGUI _time;

    public void FillLabel(string repetition, string score, int time)
    {
        base.FillLabel(repetition, score);
        _time.text = time.ToString();

    }

}