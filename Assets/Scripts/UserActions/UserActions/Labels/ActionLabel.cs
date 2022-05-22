using TMPro;
using UnityEngine;

public class ActionLabel : MonoBehaviour
{
    [SerializeField]TextMeshProUGUI Repetition,ActionScore;

    public ActionLabel(string repetition, string score)
    {
        Repetition.text = repetition;
        ActionScore.text = score;
    }
}
