using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionButtonMenu : MonoBehaviour
{
    public UserActionButton[] actionButtons;

    private void Reset()
    {
        GetActionButtons();
    }
    public void GetActionButtons()
    {
        actionButtons = new UserActionButton[gameObject.transform.childCount];
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            GameObject actionButton = transform.GetChild(i).gameObject;
            if (actionButton.TryGetComponent<UserActionButton>(out UserActionButton button))
            {
                actionButtons[i] = button;
            }
            else
            {
                Debug.LogError("One or more ActionButtons Lacks ActionScripts");
            }
        }
    }


}
