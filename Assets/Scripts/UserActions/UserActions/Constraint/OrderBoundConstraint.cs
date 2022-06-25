using System;
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
    public bool CompareActionType(UserAction ac)
    {
        if (ac.GetType() == TypeOfInterest)
        {
            return true;
        }
        else return false;
    }
    /// <summary>
    /// Compare and return true if input action equals 
    /// </summary>
    /// <param name="ac"></param>
    /// <returns></returns>
    public bool FindAction(UserAction ac)
    {
        if (Equals(targetAction))
            return true;
        else
            return false;
    }
    public override void CheckConstraint()
    {
        typeOfInterest = typeof(ActionType);

        var actionList = ActionList.UserActionList;

        if (orderType == OrderType.before)
        {

            if (actionList.Count > 0)
            {
                if (actionList.FindIndex(0, actionList.Count, FindAction) < actionList.FindLastIndex(CompareActionType)) ;
            }

        }

        else if (orderType == OrderType.after)
        {
            if (actionList.Count >
                ActionList.UserActionList.FindLastIndex(0, 1, x => x.Equals(typeOfInterest)));
        }
    }
}
