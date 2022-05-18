using UnityEngine;

public class Hede:MonoBehaviour
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
            Debug.Log("hede");

            GameObject actionButton = transform.GetChild(i).gameObject;
            if (actionButton.TryGetComponent<UserAction>(out UserAction action))
            {
                Debug.Log("hede");
                actionButtons[i] = action;
            }
            else
            {
                Debug.LogError("One or more ActionButtons Lacks ActionScripts");
            }
        }
    }
}
