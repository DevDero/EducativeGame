using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BreathControl : MonoBehaviour 
{
    [SerializeField] Animation anim;
    [SerializeField] UnityAction action;

    IEnumerator BreathControlRoutine()
    {
        anim.Play();
        ActionButtonManager.Instance.HideActionMenu();
        while (anim.isPlaying)
        {
            yield return null;
        }

        ActionButtonManager.Instance.ShowActionMenu();
    }
    public void StartBreathControlRoutine()
    {
        StartCoroutine(BreathControlRoutine());
    }


}
