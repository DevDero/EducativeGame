using UnityEngine;

public class PhoneAction : UserAction
{
    private bool has112Called { get { if (PopUpManager.PopUpManagerInitialized) return PopUpManager.AmbulanceItem.isPanelActive; else return false; } }

    public override void CheckButtonStatus(UserActionButton button)
    {
        if (has112Called) button.gameObject.SetActive(false);   
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
