public class BreathSupportAction : UserAction
{
    public bool phoneConstraint { get; set; }
    public bool hasCPRValidated { get; set; }
    public override void AddAction(AddingMod mod = AddingMod.Increment)
    {
        base.AddAction(mod);
    }
    public override void CheckGoal()
    {
        OrderBoundConstraint<CPRAction> CPRConstraint = new OrderBoundConstraint<CPRAction>(ActionConstraint.OrderType.before, this);
        OrderBoundConstraint<PhoneAction> PhoneConstraint = new OrderBoundConstraint<PhoneAction>(ActionConstraint.OrderType.ever, this);

        UserAction cPRAction;
        phoneConstraint = PhoneConstraint.CheckConstraint();
        CPRConstraint.CheckConstraint(out cPRAction);
        if(cPRAction != null)   
        if (cPRAction.Repetition > 25 && cPRAction.Repetition < 35) hasCPRValidated = true;
    }
}

