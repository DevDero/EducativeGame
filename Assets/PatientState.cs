using UnityEngine;

public class PatientState : MonoBehaviour
{
    public bool isStateActive { get { return Visual.activeSelf; } }
    [SerializeField] GameObject Visual;

    public void Activate()
    {
        Visual.SetActive(true);
    }
    public void Disable()
    {
        Visual.SetActive(false);
    }


}
