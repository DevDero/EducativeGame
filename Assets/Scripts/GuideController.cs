using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GuideController : MonoBehaviour
{
    [SerializeField] GameObject dialogueBox;
    [SerializeField] GameObject answerTab;
    [SerializeField] TextMeshProUGUI dialogueText,answer1,answer2;
    UnityAction acti1;
    UnityAction acti2;

    [SerializeField] Button button1, button2;
    public void StartGuide(ConversationSO conversation)
    {
        dialogueBox.SetActive(true);
        dialogueText.text = conversation.question;
        SetAnswers(conversation);
    }
    public void HideGuide()
    {
        dialogueBox.SetActive(false);
    }
    public void SetAnswers(ConversationSO conversation)
    {
        if (conversation.answer.Length > 0)
        {
            answerTab.SetActive(true);
            answer1.text = conversation.answer[0].answer;
            answer2.text = conversation.answer[1].answer;

            acti1 += conversation.answer[1].AnswerCallBack.Invoke;
            acti2 += conversation.answer[2].AnswerCallBack.Invoke;

            button1.onClick.AddListener(acti1);
            button2.onClick.AddListener(acti2);

        }
        else
            answerTab.SetActive(false);
    }
}
