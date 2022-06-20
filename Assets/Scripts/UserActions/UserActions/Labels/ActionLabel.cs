using TMPro;
using UnityEngine;
public abstract class ActionLabel : MonoBehaviour 
{
    public abstract UserAction Action { get ; set ; }

    [SerializeField] protected TextMeshProUGUI Repetition;
    [SerializeField] protected StarScoreElement ActionScore;


    public abstract void FillLabel();
}
