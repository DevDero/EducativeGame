using UnityEngine;
public interface IBasicPanel
{

    public GameObject PanelItem { get;}

    public void ActivatePanel(GameObject PanelElement)
    {
        PanelElement.SetActive(true);
    }
    public void DisablePanel(GameObject PanelElement)
    {
        PanelElement.SetActive(false);
    }


}