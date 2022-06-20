public class BreathControlAction : UserAction
{
    private int durationBeforeAction;

    public override void AddAction()
    {
        _Duration = durationBeforeAction;
        base.AddAction();
    }

    private void GetDurationBeforeAction()
    {
        durationBeforeAction = (int)GeneralManager.Instance.LevelTime;
    }
}
