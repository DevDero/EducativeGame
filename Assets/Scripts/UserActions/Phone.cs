using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Phone : MonoBehaviour
{
    public GameObject phoneButton;
    public int correctNumber = 112;
    [SerializeField]TextMeshProUGUI inputfield;
    [SerializeField]Animator animator;

    public void WriteFromNumPad(int i)
    {
        inputfield.text = inputfield.text + i;
    }
    public void Erase()
    {
        string beforeErase = inputfield.text;

        if(beforeErase.Length>1)
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
        if( Int32.Parse(inputfield.text) == correctNumber)
        {
            OpenConversation();
            ClosePhone();
        }

    }
    public void OpenConversation()
    {
        ConversationManager.Instance.StartConversation();
    }
}
