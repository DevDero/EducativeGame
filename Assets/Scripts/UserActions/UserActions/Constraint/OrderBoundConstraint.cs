using System;
using System.Collections.Generic;
/// <summary>
/// 
/// </summary>
/// <typeparam name="ActionType">Action Type you want to compare</typeparam>
public class OrderBoundConstraint<ActionType> : ActionConstraint where ActionType : UserAction
{
    Type typeOfInterest;

    UserAction targetAction;
    OrderType orderType;

    public Type TypeOfInterest { get => typeOfInterest; set => typeOfInterest = value; }

    public OrderBoundConstraint(OrderType orderType, UserAction action)
    {
        this.targetAction = action;
        this.orderType = orderType;
    }
    
    /// <summary>
    /// Compare type of Action
    /// </summary>
    /// <param name="ac"></param>
    /// <returns></returns>
    private bool CompareActionType(UserAction ac)
    {
        if (ac.GetType() == TypeOfInterest)
        {
            return true;
        }
        else return false;
    }
    /// <summary>
    /// Compare and return true if input action Reference Equals  to exact on list
    /// </summary>
    /// <param name="ac"></param>
    /// <returns></returns>
    private bool FindAction(UserAction ac)
    {
        if (ReferenceEquals(targetAction,ac))
            return true;
        else
            return false;
    }

    
    public void CustomInternalFunc()
    {

    }

    public override void CheckConstraint(ResponseToConstraint response)
    {
    }
    public override bool CheckConstraint(out UserAction actionOfInterest)
    {
        typeOfInterest = typeof(ActionType);

        var actionList = ActionList.UserActionList;
        actionOfInterest = null;


        if (actionList.Count > 0)
        {
            List<UserAction> interestList = actionList.FindAll(CompareActionType);

            int targetIndex = targetAction.Order;


            if (interestList.Count > 0)
            {
                foreach (var interest in interestList)
                {
                    
                    if (interest.Order < targetIndex)
                    {
                        if (actionOfInterest != null) 
                        {
                            if (actionOfInterest.Order > interest.Order)
                                actionOfInterest = interest;
                        }
                        else
                        actionOfInterest = interest;
                    }
                }
            }
        }


        if (actionOfInterest != null) return true;
        else return false;


    }

    public override bool CheckConstraint()
    {
        typeOfInterest = typeof(ActionType);

        var actionList = ActionList.UserActionList;
        UserAction actionOfInterest = null;


        if (actionList.Count > 0)
        {
            List<UserAction> interestList = actionList.FindAll(CompareActionType);

            int targetIndex = targetAction.Order;


            if (interestList.Count > 0)
            {
                foreach (var interest in interestList)
                {

                    if (interest.Order > targetIndex)
                    {
                        if (actionOfInterest != null)
                        {
                            if (actionOfInterest.Order < interest.Order)
                                actionOfInterest = interest;
                        }
                        else
                            actionOfInterest = interest;
                    }
                }
            }
        }


        if (actionOfInterest != null) return true;
        else return false;
    }
}
