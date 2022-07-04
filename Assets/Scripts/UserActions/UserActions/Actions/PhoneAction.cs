using UnityEngine;

public class PhoneAction : UserAction
{
    private bool has112Called { get { if (PopUpManager.PopUpManagerInitialized) return PopUpManager.AmbulanceItem.isPanelActive; else return false; } }
    public bool HasBreathChecked { get; set; }
    public bool UnnecessaryCPR { get; set; }

    public override void CheckButtonStatus(UserActionButton button)
    {
        if (has112Called) button.gameObject.SetActive(false);   
    }
    public override void CheckGoal()
    {
        OrderBoundConstraint<BreathControlAction> BreathCheck = new OrderBoundConstraint<BreathControlAction>(ActionConstraint.OrderType.before, this);
        HasBreathChecked = BreathCheck.CheckConstraint();

        OrderBoundConstraint<CPRAction> CPR = new OrderBoundConstraint<CPRAction>(ActionConstraint.OrderType.before, this);
        OrderBoundConstraint<BreathSupportAction> BS = new OrderBoundConstraint<BreathSupportAction>(ActionConstraint.OrderType.before, this);

        if (CPR.CheckConstraint() || BS.CheckConstraint()) UnnecessaryCPR = true;
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
