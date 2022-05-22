using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionButtonMenu : MonoBehaviour
{
    public UserAction[] actionButtons;

    private void Reset()
    {
        GetActionButtons();
    }
    public void GetActionButtons()
    {
        actionButtons = new UserAction[gameObject.transform.childCount];
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            GameObject actionButton = transform.GetChild(i).gameObject;
            if (actionButton.TryGetComponent<UserAction>(out UserAction action))
            {
                actionButtons[i] = action;
            }
            else
            {
                Debug.LogError("One or more ActionButtons Lacks ActionScripts");
            }
        }
    }


}
