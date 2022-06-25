﻿using System.Linq;
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
    readonly bool isMockAction = false;

    public GameObject _LabelPrefab;

    protected int _Repetition, _Score;
    protected float _Duration;
    private ActionStatus actionStatus;
    private ActionConstraint[] constraints;

    public int Repetition { get => _Repetition; }
    public float Duration { get => _Duration; }
    public int Score { get => _Score; }
    public ActionStatus ActionStatus { get => actionStatus; set => actionStatus = value; }
    public virtual ActionConstraint[] Constraints { get => constraints; set => constraints = value; }

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

    #region List Methods
    public virtual void AddAction()
    {
        actionStatus = ActionStatus.Finished;
        
        ActionList.UserActionList.Add(this);
    }

    public virtual void AddAction(AddingMod mod=AddingMod.Increment)
    {
        actionStatus = ActionStatus.Finished;

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
