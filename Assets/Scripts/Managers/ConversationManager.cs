using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ConversationManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI[] answers;
    [SerializeField] Button[] buttons;
    [SerializeField] TextMeshProUGUI question;
    [SerializeField] ConversationSO conversation;
    [SerializeField] GameObject conversationElement;


    UnityAction acti;
    public static ConversationManager Instance;
    private void Awake()
    {
        Instance = this;
    }
    public void StartConversation()
    {
        SetTexts();
        conversationElement.SetActive(true);
    }
    public void StopConversation()
    {
        conversationElement.SetActive(false);
    }
  
    public void SetTexts()
    {
        ClearText();
        var answerArray = conversation.answer;
        question.text = conversation.question;
        for (int i = 0; i < answerArray.Length; i++)
        {
            answers[i].text = answerArray[i].answer;

            if (answerArray[i].AnswerCallBack.GetPersistentEventCount() > 0)
            {
                acti += answerArray[i].AnswerCallBack.Invoke;
                buttons[i].onClick.AddListener(acti);
            }
        }

    }
    public void CheckButtons()
    {
        
    }
    public void DisableButtons()
    {
        foreach (var button in buttons)
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
        foreach (var item in answers)
        {
            item.text = "";
        }
    }
    public void ChangeText(int nextIndex)
    {
        if(conversation.answer[nextIndex].nextQA)
        conversation = conversation.answer[nextIndex].nextQA;

        SetTexts();
    }
}
