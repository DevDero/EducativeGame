using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpManager : MonoBehaviour
{
    public static PopUpManager Instance;
    private PopQuiz PopQuiz;
    [SerializeField] public static GameObject restart, ambulance, warning, tips, endlevel;
    public QuizTemplate[] quizTemplates;


    private void OnEnable()
    {
        Instance = this;
        
        restart = gameObject.transform.GetChild(0).gameObject;
        warning = gameObject.transform.GetChild(2).gameObject;
        tips = gameObject.transform.GetChild(3).gameObject;
        ambulance= gameObject.transform.GetChild(4).gameObject;
        endlevel = gameObject.transform.GetChild(5).gameObject;
        PopQuiz = gameObject.transform.GetChild(1).GetComponentInChildren<PopQuiz>();
    }
    public void OpenTip(string tip)
    {
        tips.SetActive(true);
        tips.GetComponent<TipPopUp>().text.text = tip;
    }
    public void OpenQuiz(string QuizName)
    {
        PopQuiz.LaunchPopQuiz(QuizName);
    }
    public static void OpenEndLevel()
    {
        endlevel.SetActive(true);
    }

    public static void OpenPopUp()
    {
        restart.SetActive(true);
    }
    public static void StartCountDown()
    {
        ambulance.SetActive(true);
    }
}

public enum Popups { restart, popquiz, warning, ambulance, endlevel }
