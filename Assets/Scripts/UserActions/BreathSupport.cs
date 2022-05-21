using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BreathSupport : MonoBehaviour
{
    [SerializeField]Animation supportBreathAnimation;
    [SerializeField] UserCharacterController charater;
    public BreathSupportAction analyse;

    IEnumerator SupportBreath()
    {
        supportBreathAnimation.Play();
        ActionButtonManager.Instance.HideActionMenu();
        while (supportBreathAnimation.isPlaying)
        {
            yield return null;
        }
        ActionButtonManager.Instance.ShowActionMenu();

        charater.SwitchPose("Crouch");
    }
    public void BreathSupportRoutine()
    {
        analyse.AddAction();
        StartCoroutine(SupportBreath());
    }
}
