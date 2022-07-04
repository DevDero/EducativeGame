using System;
using UnityEngine;

public interface IBasicPanel
{
    public Action OnActivation { get; set; }

    protected GameObject PanelItem { get;}

    public void ActivatePanel()
    {
        PanelItem.SetActive(true);
    }
    public void ActivatePanelWitchAction()
    {
        if(OnActivation!=null)
            OnActivation.Invoke();

        PanelItem.SetActive(true);
    }
    public void DisablePanel()
    {
        //if(OnActivation!=null) 
        //    OnActivation = null;

        PanelItem.SetActive(false);
    }

}