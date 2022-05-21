using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;
public class PopQuiz : MonoBehaviour
{
    [SerializeField]TextMeshProUGUI question;
    [SerializeField]TextMeshProUGUI answer1,answer2,answer3,answer4;
    [SerializeField] private Button[]_AnswerButtons=new Button[4]; 
     private QuizTemplate _template;
     private Animation anim;
     
     public void SetQuiz()
    {
        _template.FillQuiz(question, answer1, answer2, answer3, answer4);
    }
     
     public bool CheckAnswer(string selectedAnswer)
     {
         DisableAllButtons();
         if (selectedAnswer == _template._CorrectAnswer)
             return true;
         else return false;
     }

     public void DisableAllButtons()
     {
         foreach (var button in _AnswerButtons)
         {
             button.interactable=false;
         }
     }
     public void AnimateQuiz()
     {
         
     }
     
     
}

[CreateAssetMenu(fileName = "QuizTemplate",menuName = "QuizTypes",order = 2)]
public class QuizTemplate : ScriptableObject
{
    [SerializeField] private string[] _Answers = new string[4];
    [SerializeField] public string _CorrectAnswer; 
    [SerializeField] private string _Question;

    public void FillQuiz(TextMeshProUGUI question, TextMeshProUGUI answer1, 
        TextMeshProUGUI answer2,
        TextMeshProUGUI answer3,
        TextMeshProUGUI answer4)
    {
        question.text = _Question;
        answer1.text = _Answers[0];
        answer1.text = _Answers[1];
        answer1.text = _Answers[2];
        answer1.text = _Answers[3];

    }

}