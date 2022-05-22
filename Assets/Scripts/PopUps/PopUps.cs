using System;
using UnityEngine;

public class PopUps : MonoBehaviour, IBasicPanel
{

    public IBasicPanel panel { get { return GetComponent<IBasicPanel>(); } }

    public virtual Action OnActivation { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    GameObject IBasicPanel.PanelItem => transform.GetChild(0).gameObject;

}
