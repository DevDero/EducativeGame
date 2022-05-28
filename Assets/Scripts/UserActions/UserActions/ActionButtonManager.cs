using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionButtonManager : MonoBehaviour
{
    [SerializeField] GameObject ActionButtonElement;
    [SerializeField] ActionButtonMenu[] menus;
    public bool actionButtonVisible;
    public static ActionButtonManager Instance;

    private void Awake()
    {
        Instance = this;
    }
    public void ChangeMenu(ActionButtonMenu menu)
    {
        foreach (var item in menus)
        {
            item.gameObject.SetActive(false);
        }
        menu.gameObject.SetActive(true);
    }
    public void DefaultMenu()
    {
        foreach (var item in menus)
        {
            item.gameObject.SetActive(false);
        }
        menus[0].gameObject.SetActive(true);
    }

    public void HideActionMenu()
    {
        ActionButtonElement.SetActive(false);
    }
    public void ShowActionMenu()
    {
        ActionButtonElement.SetActive(true);
    }
    private void ObligatedBreathControl()
    {
        GeneralManager.Instance.StopConversation();
        ShowActionMenu();

    }
    public void DelayedObligatedBreathControl()
    {
        Invoke("ObligatedBreathControl", 2);
    }
}


