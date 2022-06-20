using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BreathControl : MonoBehaviour 
{
    [SerializeField] Animation anim;
    [SerializeField] UnityAction action;
    private UserAction breathAction;
    public void Start()
    {
        breathAction = GetComponent<UserAction>();
    }
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
        breathAction.AddAction();
        StartCoroutine(BreathControlRoutine());
    }


}
