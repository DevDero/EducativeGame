using UnityEngine;

public class PhoneAction : UserAction
{
    private bool has112Called { get { if (PopUpManager.PopUpManagerInitialized) return PopUpManager.AmbulanceItem.isPanelActive; else return false; } }
    private bool hasBreathChecked;


    public override void CheckButtonStatus(UserActionButton button)
    {
        if (has112Called) button.gameObject.SetActive(false);   
    }
    public override void CheckGoal()
    {
        OrderBoundConstraint<BreathControlAction> BreathCheck = new OrderBoundConstraint<BreathControlAction>(ActionConstraint.OrderType.before, this);
        hasBreathChecked = BreathCheck.CheckConstraint();
    }

    private void CheckConversation()
    {
        if (ActionStatus == ActionStatus.Started && has112Called) 
        {
            AddAction();
        }
    }

    private void Update()
    {
        CheckConversation();
    }
}
