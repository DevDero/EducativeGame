using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patient : MonoBehaviour
{
    [SerializeField]PatientState[] States;
    private void OnEnable()
    {
        CheckState();
    }

    public void CheckState()
    {
        int activeStateCount=0;
        foreach (var state in States)
        {
            if (state.isStateActive == true)
                activeStateCount++;
        }
        if (activeStateCount > 1) Debug.Log(this + "MORE THAN 1CHARACTER STATES IS ACTIVE");
    }
    public void OnTheFloor()
    {
        States[0].Activate();
        States[1].Disable();
    }
    public void Stretcher()
    {
        States[0].Disable();
        States[1].Activate();
    }

}
