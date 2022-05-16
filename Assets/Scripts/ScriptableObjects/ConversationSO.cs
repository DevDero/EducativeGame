using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Conversation", menuName = "ScriptableObjects/Conversation", order = 3)]


public class ConversationSO : ScriptableObject
{
    public string question;
    public Answer[] answer;
}


[Serializable]
public class Answer
{
    public string answer;
    public ConversationSO nextQA;
    public UnityEvent AnswerCallBack;
}
