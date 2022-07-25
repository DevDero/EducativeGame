using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CPR : MonoBehaviour
{
    [SerializeField] Animation anim;
    [SerializeField] Slider slider;
    [SerializeField] Slider autoSlider;
    [SerializeField] CPRAction action;
    [SerializeField] GameObject automaticWarning;


    [SerializeField]private UserCharacterController CharacterController;
    private Coroutine autoCompressionRoutine;

    private void OnEnable()
    {
        if (action.Automated)
        {
            AutoCompression();
            autoSlider.onValueChanged.AddListener(delegate { StopAutoCompression(); } ); 
        }
        action.sliderValue = slider.value;
        action.StartCompressionCheck();
    }

    public void Movement()
    {
        anim["CPR+"].time = slider.value;
        anim["CPR+"].speed = 0;
        anim.Play("CPR+");

        action.sliderValue = slider.value;
        action.GetCompressionSens();
    }
    public IEnumerator AutomatedCompression()
    {

        for (int i = 0; i < 60;)
        {
            if (i % 2 == 0)
            {
                anim.Play("CPR+");
                do
                {
                    yield return null;
                    anim["CPR+"].speed = 1.1f;
                }
                while (anim.isPlaying);
                i++;
            }
            else if (i % 2 != 0)
            {
                anim.Play("CPR-");
                do
                {
                    yield return null;
                    anim["CPR-"].speed = 1.1f;
                }
                while (anim.isPlaying);
                i++;
            }
            action.AutoCPRCounter();
        }

        action.AddAction();
        slider.value = 0;
        ActionButtonManager.Instance.ChangeMenu(ActionButtonManager.Instance.menus[1]);
        CharacterController.SwitchPose("Standing");

    }
    public void AutoCompression()
    {
        automaticWarning.SetActive(true);
       autoCompressionRoutine = StartCoroutine(AutomatedCompression());
    }
    public void StopAutoCompression()
    {
        automaticWarning.SetActive(false);
        if (autoCompressionRoutine != null) StopCoroutine(autoCompressionRoutine);
    }
}
