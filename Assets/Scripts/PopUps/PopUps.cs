using UnityEngine;

public class PopUps : MonoBehaviour, IBasicPanel
{
    public GameObject PanelItem { get => transform.GetChild(0).gameObject; }
}
