using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public enum AddingMod { Increment }

public class UserAction : MonoBehaviour
{
    public GameObject _LabelPrefab;

    protected int _Repetition;
    protected int _Score;

    protected virtual int RepetitionGoal { get; set; }

    private void OnEnable()
    {
        CheckButtonStatus();
    }

    public virtual void AddAction()
    { 
    }

    public virtual void AddAction(int repetition,int ScorePercentage)
    {
        _Repetition = repetition;
        _Score = ScorePercentage;
        ActionList.UserActionList.Add(this);
    }

    public void AddAction(int repetition, int ScorePercentage, AddingMod mod=AddingMod.Increment)
    {
        if (ActionList.UserActionList.Count == 0)
        {
            CheckGoal();
            ActionList.UserActionList.Add(this);
        }
        else
        {
            var userAction = ActionList.UserActionList.Last();

            if (userAction.GetType() == this.GetType())
            {
                userAction._Repetition++;
                userAction.CheckGoal();
            }
            else
            {
                CheckGoal();
                ActionList.UserActionList.Add(this);
            }
        }

    }

    public virtual void CreateLabel(Transform content)
    {
        Debug.Log(_LabelPrefab);
        var currentLabel = GameObject.Instantiate<GameObject>(_LabelPrefab, content).GetComponent<ActionLabel>();
        Debug.Log(currentLabel);
        currentLabel.FillLabel(_Repetition.ToString(), _Score.ToString());
    }
    
    public virtual void CheckGoal()
    {
        if (RepetitionGoal != _Repetition)
            Debug.Log("A goal not meet"); 
    }
    public virtual void CheckButtonStatus()
    {

    }
}
