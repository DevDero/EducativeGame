using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BreathControl : MonoBehaviour 
{
    [SerializeField] Animation animation;
    [SerializeField] UnityAction action;


    IEnumerator BreathControlRoutine()
    {
        animation.Play();
        ActionButtonManager.Instance.HideActionMenu();
        while (animation.isPlaying)
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
