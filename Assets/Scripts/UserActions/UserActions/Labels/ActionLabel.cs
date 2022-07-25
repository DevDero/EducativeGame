using TMPro;
using UnityEngine;
public abstract class ActionLabel : MonoBehaviour 
{
    public abstract UserAction Action { get ; set ; } 
    public AnimationCurve curve;
    public float score;

    [SerializeField] protected TextMeshProUGUI Repetition;
    [SerializeField] protected StarScoreElement ActionScore;


    public abstract void FillLabel();

    public abstract float CalculateScore();
}
