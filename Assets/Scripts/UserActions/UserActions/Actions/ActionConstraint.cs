using System;
using UnityEngine;

public class ActionConstraint
{
    string suggestionText;
    public enum OrderType { before, after };


    public virtual void CheckConstrint()
    {
    }
}

/// <summary>
/// 
/// </summary>
/// <typeparam name="ActionType">Action Type you want to compare</typeparam>
public class OrderBoundConstraint<ActionType> : ActionConstraint where ActionType : UserAction
{
    ActionType actionOfInterest;
    Type typeofInterest;

    UserAction targetAction;
    OrderType orderType;

    public OrderBoundConstraint(OrderType orderType, UserAction action)
    {
        this.targetAction = action;
        this.orderType = orderType;
    }
    public void FindAction()
    {
        typeofInterest = typeof(ActionType);
    }
    public bool ListMethod(UserAction ac)
    {
        if (ac.GetType() == typeofInterest)
        {
            return true;
        }
        else return false;
    }
    public bool EqualAction(UserAction ac)
    {
        if (Equals(targetAction))
            return true;
        else
            return false;
    }
    public override void CheckConstrint()
    {
        FindAction();

        if (orderType == OrderType.before)
        {
            var actionList = ActionList.UserActionList;

            if (actionList.Count > 0)
            {

                if (actionList.FindIndex(0, actionList.Count, EqualAction) < actionList.FindLastIndex(0, actionList.Count, ListMethod))
                    Debug.Log("hede");
            }

        }

        //else if (orderType == OrderInList.after)
        //{
        //    if (actionOrder >
        //        ActionList.UserActionList.FindLastIndex(0, 1, x => x.Equals(actionOfInterest)))
        //        hede = true;
        //    else hede = false;
        //}
    }

}
