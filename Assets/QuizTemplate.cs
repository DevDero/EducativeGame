using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "QuizTemplate",menuName = "QuizTypes/QCM",order = 2)]
public class QuizTemplate : ScriptableObject
{
    [SerializeField] public string[] _Answers = new string[4];
    [SerializeField] public string _CorrectAnswer; 
    [SerializeField] public string _Question;

   

}
