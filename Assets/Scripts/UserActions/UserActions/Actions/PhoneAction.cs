public class PhoneAction : UserAction
{
    private bool has112Called { get { return PopUpManager.AmbulanceItem.isPanelActive;} }

    public override void CheckButtonStatus()
    {
        if (has112Called) gameObject.SetActive(false);
        base.CheckButtonStatus();
    }
}
