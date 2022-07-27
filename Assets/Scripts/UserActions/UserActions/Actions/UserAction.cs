using System.Linq;
using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public enum AddingMod { Increment }
public enum ActionStatus { Inactive ,Started ,Finished ,Paused ,Interrupted}
public class UserAction : MonoBehaviour
{
    /// <summary>
    /// This field represent actions created for typeReflection in constraints 
    /// </summary>

    public GameObject _LabelPrefab;

    protected int _Repetition;
    protected float _Duration;
    private ActionStatus actionStatus;
    internal ActionConstraint[] constraints;
    private int order;

    public int Repetition { get => _Repetition; }
    public float Duration { get => _Duration; }
    public ActionStatus ActionStatus { get => actionStatus; set => actionStatus = value; }
    public virtual ActionConstraint[] Constraints { get => constraints; set => constraints = value; }
    
    public int Order { get => order;}

    #region Unity Methods
    private void OnEnable()
    {
        CheckButtonStatus();
    }
    private void FixedUpdate()
    {
        if(actionStatus == ActionStatus.Started)
        Timer();
    }
    #endregion
    internal virtual void CleanUserAction()
    {
        _Repetition = 0;
        _Duration = 0;

    }

    #region List Methods
    public virtual void AddAction()
    {
        actionStatus = ActionStatus.Finished;
        this.order = ActionList.UserActionList.Count;
        UserAction actionImage = (UserAction)this.MemberwiseClone();
        ActionList.UserActionList.Add(actionImage);
        CleanUserAction();
    }

    public virtual void AddAction(AddingMod mod=AddingMod.Increment)
    {
        actionStatus = ActionStatus.Finished;
        this.order = ActionList.UserActionList.Count;

        if (ActionList.UserActionList.Count == 0)
        {
            this._Repetition++;
            UserAction actionImage = (UserAction)this.MemberwiseClone();
            ActionList.UserActionList.Add(actionImage);
        }
        else
        {
            var userAction = ActionList.UserActionList.Last();

            if (userAction.GetType() == this.GetType())
            {
                this._Repetition++;
                userAction._Repetition++;
            }
            else
            {
                UserAction actionImage = (UserAction)this.MemberwiseClone();
                ActionList.UserActionList.Add(actionImage);
                this._Repetition++;
            }
        }
    }
    #endregion

    #region CommonMethods
    public virtual void WriteLabels(Transform content,UserAction action)
    {
        ActionLabel label = GameObject.Instantiate<GameObject>(_LabelPrefab, content)
            .GetComponent<ActionLabel>();

        label.Action = action;                                                                  
        label.FillLabel();
    }
    public virtual void CheckGoal()
    {

    }
    public virtual void CheckButtonStatus()
    {
    }
    public virtual void CheckButtonStatus(UserActionButton button)
    {
    }
    private void Timer()
    {
        _Duration += Time.fixedDeltaTime;
    }
    #endregion
}
