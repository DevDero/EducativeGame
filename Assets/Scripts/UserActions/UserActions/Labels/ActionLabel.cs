using TMPro;
using UnityEngine;
public class ActionLabel : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Repetition, ActionScore;

    public virtual void FillLabel(string repetition, string score)
    {
        Repetition.text = repetition;
        ActionScore.text = score;
    }

}
public class PhoneLabel : ActionLabel
{
    [SerializeField] float _time;

    public void FillLabel(string repetition, string score, float time)
    {
        base.FillLabel(repetition, score);
        _time = time;
    }

}