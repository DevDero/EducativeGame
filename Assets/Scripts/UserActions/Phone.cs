using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Phone : MonoBehaviour
{
    public int correctNumber = 112;
    [SerializeField] TextMeshProUGUI inputfield;
    [SerializeField] Animator animator;
    [SerializeField] GameObject wrongNumberPrefab;
    [SerializeField] PhoneAction phoneAction;

    public void WriteFromNumPad(int i)
    {
        if (inputfield.text.Length < 12) 
        inputfield.text = inputfield.text + i;
    }
    public void Erase()
    {
        string beforeErase = inputfield.text;

        if(beforeErase.Length>0)
        inputfield.text = beforeErase.Remove(beforeErase.Length - 1);
    }
    public void ClosePhone()
    {
        animator.SetBool("IsPhoneOpen", false);
    }
    public void OpenPhone()
    {
        animator.SetBool("IsPhoneOpen", true);
    }
    public void CallNumber()
    {
        if (Int64.Parse(inputfield.text) == correctNumber)
        {
            phoneAction.AddAction();
            OpenConversation();
            ClosePhone();
        }
        else
            StartCoroutine(WorngNumberRoutine(3));
    }
    public void OpenConversation()
    {
        ConversationManager.Instance.StartConversation();
    }
    IEnumerator WorngNumberRoutine(float duration)
    {
        wrongNumberPrefab.SetActive(true);
        yield return new WaitForSeconds(duration);
        wrongNumberPrefab.SetActive(false);

        inputfield.text = "";
    }
}
