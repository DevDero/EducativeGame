﻿public class PhoneAction : UserAction
{
    private bool has112Called { get { return PopUpManager.Ambulance.gameObject.activeSelf; } }

    public override void CheckButtonStatus()
    {
        if (has112Called) gameObject.SetActive(false);
        base.CheckButtonStatus();
    }
}