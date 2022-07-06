using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ConversationManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI[] answersTMP;
    [SerializeField] Button[] answerButtons;
    [SerializeField] TextMeshProUGUI questionTMP;
    [SerializeField] ConversationSO conversationSO;

    [SerializeField] GameObject conversationElement;


    UnityAction onButtonClick;
    public static ConversationManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    public void StartConversation()
    {
        SetTexts();
    }
    public void StopConversation()
    {
        conversationElement.SetActive(false);
    }
  
    public void SetTexts()
    {
        ClearText();

        Answer[] answerArray = conversationSO.answer;
        questionTMP.text = conversationSO.question;

        for (int i = 0; i < answerArray.Length; i++)
        {
            answersTMP[i].text = answerArray[i].answer;
            
            if (answerArray[i].AnswerCallBack.GetPersistentEventCount() > 0)
            {
                onButtonClick += answerArray[i].AnswerCallBack.Invoke;
                answerButtons[i].onClick.AddListener(onButtonClick);
            }   
        }
        for (int i = 0; i < 4; i++)
        {
            answerButtons[i].interactable = isButtonInteractable(i);
        }
    }
    
    public bool isButtonInteractable(int index)
    {
        if (answersTMP[index].text == "") return false;
        else return true;
        
    }

    public void DisableButtons()
    {
        foreach (var button in answerButtons)
        {
             button.interactable = false;
        }
    }
    //public void AddSingleClickCheck()
    //{
    //    foreach (var button in buttons)
    //    {
    //        button.onClick.AddListener(() => DisableButtons());
    //        button.interactable = true;
    //    }
    //}

    public void ClearText()
    {
        foreach (var item in answersTMP)
        {
            item.text = "";
        }
    }
    public void ChangeText(int nextIndex)
    {
        if (conversationSO.answer[nextIndex].nextQA)
            conversationSO = conversationSO.answer[nextIndex].nextQA;

        SetTexts();
    }
}
