using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;
public class PopQuiz : PopUps
{
    [SerializeField] private AnswerButton[] answerButtons = new AnswerButton[4];
    [SerializeField] QuizTemplate[] quizTemplates;
    [SerializeField] TextMeshProUGUI question;
    [SerializeField] private Button continueButton;
    [SerializeField] private QuizAction quizAction;

    private QuizTemplate _template;
    private Animation anim;


    
    #region Private Methods
    private void SetButtonEvents()
    {
        foreach (var item in answerButtons)
        {
            var text = item.answerTMP.text;
            item.onClick.AddListener(() => AnimateQuiz(text,item));
            item.onClick.AddListener(OnAnswerSelected);
        }
    }

    private void ChargeTemplates(string quizName)
    {
        foreach (QuizTemplate template in quizTemplates)
        {
            if (quizName == template.ToString())
            {
                _template = template;
            }
        }
        if (_template == null)
            Debug.Log("Wops! templates couldnt load");
    }

    private void SetQuiz()
    {
        question.text = _template._Question;

        for (int i = 0; i < 4; i++)
        {
            answerButtons[i].answerTMP.text = _template._Answers[i];
        }
    }

    private void OnAnswerSelected()
    {
        ShowContinueButton();
        DisableAllButtons();
        ShowCorrectButton();

    }

    private void AnimateQuiz(string selectedAnswer, Button button)
    {
        if (selectedAnswer == _template._CorrectAnswer)
        {
            button.image.color = Color.green;
            quizAction.result = true;
            quizAction.AddAction(1,100);
        }
        else
        {
            button.image.color = Color.red;
            quizAction.result = false;
            quizAction.AddAction(1,0);
        }
    }

    private void ShowContinueButton()
    {
        continueButton.gameObject.SetActive(true);
    }

    private void DisableAllButtons()
    {

        foreach (AnswerButton button in answerButtons)
        {
            button.interactable = false;
        }
    }

    private void ShowCorrectButton()
    {
        foreach (var item in answerButtons)
        {
            if (_template._CorrectAnswer == item.answerTMP.text)
                item.image.color = Color.green;
        }
    }

    private void ResetQuiz()
    {
        continueButton.gameObject.SetActive(false);
        ResetButtons();
        Time.timeScale = 1;
    }

    private void ResetButtons()
    {
        foreach (var item in answerButtons)
        {
            item.onClick.RemoveAllListeners();
            item.interactable = true;
            item.image.color = new Color(255, 234, 220);
        }
    }
    #endregion
    
    #region Public Methods
    
    public void LaunchPopQuiz(string quizName)
    {
        Time.timeScale = 0;

        panel.ActivatePanel();
        ChargeTemplates(quizName + " (QuizTemplate)");
        if (_template == null)
        {
            Debug.LogError("Big Problem m8, empty quiz arrived");
            transform.GetChild(0).gameObject.SetActive(false);
        }
        else
        {
            SetQuiz();
            SetButtonEvents();
        }

    }

    public void TerminatePopQuiz()
    {
        panel.DisablePanel();
        ResetQuiz();
    }
    
    #endregion

}
