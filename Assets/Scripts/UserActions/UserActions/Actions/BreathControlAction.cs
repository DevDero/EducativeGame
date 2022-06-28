public class BreathControlAction : UserAction
{
    private int durationBeforeAction;

    public int DurationBeforeAction { get => durationBeforeAction; set => durationBeforeAction = value; }

    public override void AddAction()
    {
        GetDurationBeforeAction();
        _Duration = DurationBeforeAction;
        base.AddAction();
    }

    private void GetDurationBeforeAction()
    {
        DurationBeforeAction = (int)GeneralManager.Instance.LevelTime;
    }
}
