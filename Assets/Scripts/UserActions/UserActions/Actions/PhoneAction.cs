using UnityEngine;

public class PhoneAction : UserAction
{
    private bool has112Called { get { if (PopUpManager.PopUpManagerInitialized) return PopUpManager.AmbulanceItem.isPanelActive; else return false; } }

    public override void CheckButtonStatus(UserActionButton button)
    {
        if (has112Called) button.gameObject.SetActive(false);   
    }
    public override void CreateLabel(Transform content)
    {
        base.CreateLabel(content);
    }

}
