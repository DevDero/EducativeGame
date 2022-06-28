public class BreathSupportAction : UserAction
{
    public override void AddAction(AddingMod mod = AddingMod.Increment)
    {
        base.AddAction(mod);
    }
    public override void CheckGoal()
    {
        OrderBoundConstraint<CPRAction> CPRConstraint = new OrderBoundConstraint<CPRAction>(ActionConstraint.OrderType.before, this);
        UserAction cPRAction;

        CPRConstraint.CheckConstraint(out cPRAction);
    }
}

