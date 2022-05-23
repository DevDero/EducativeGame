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
