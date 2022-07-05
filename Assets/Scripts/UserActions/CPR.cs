using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CPR : MonoBehaviour
{
    [SerializeField] Animation anim;
    [SerializeField] Slider slider;
    [SerializeField] Slider autoSlider;
    [SerializeField] CPRAction action;
    [SerializeField] GameObject automaticWarning;

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

        for (int i = 0; i < 30;)
        {
            if (i % 2 == 0)
            {
                anim.Play("CPR+");
                do
                {
                    yield return null;
                    anim["CPR+"].speed = 0.7f;
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
                    anim["CPR-"].speed = 0.7f;
                }
                while (anim.isPlaying);
                i++;
            }
        }
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
