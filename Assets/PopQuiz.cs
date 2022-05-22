using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;
public class PopQuiz : MonoBehaviour
{
    [SerializeField]TextMeshProUGUI question;
    [SerializeField] private AnswerButton[] answerButtons=new AnswerButton[4];
    [SerializeField] private Button continueButton;
    private QuizTemplate _template;
    private Animation anim;
    
    public void LaunchPopQuiz(string quizName)
    {
        transform.GetChild(0).gameObject.SetActive(true);
        ChargeTemplates(quizName+" (QuizTemplate)");
        if (_template == null)
        {
            Debug.LogError("Big Problem m8, empty quiz arrived");
            transform.GetChild(0).gameObject.SetActive(false);
        }
        else
            SetQuiz();

        SetButtonEvents();

    }
    public void ClosePopQuiz()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }

    private void SetButtonEvents()
    {
        foreach (var item in answerButtons)
        {
            var text = item.answerTMP.text;
            item.onClick.AddListener(()=>CheckAnswer(text));
            item.onClick.AddListener(() => AnimateQuiz(text,item));
            item.onClick.AddListener(DisableAllButtons);
        }
    }

    private void ChargeTemplates(string quizName)
    {
        foreach (QuizTemplate template in PopUpManager.Instance.quizTemplates)
        {
            Debug.Log(quizName);
            Debug.Log(template);
            Debug.Log(quizName == template.ToString());
            if (quizName == template.ToString())
            {
                _template = template;

                Debug.Log(_template);

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

    private bool CheckAnswer(string selectedAnswer)
    {
        DisableAllButtons();
        ShowContinueButton();
        if (selectedAnswer == _template._CorrectAnswer) return true;
        else return false;
    }
    private void ShowContinueButton()
    {
        continueButton.gameObject.SetActive(true);
    }

    private void DisableAllButtons()
    {
        ShowCorrectButton();

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
    private void AnimateQuiz(string selectedAnswer,Button button)
    {
        if (selectedAnswer == _template._CorrectAnswer)
            button.image.color = Color.green;
        else
            button.image.color = Color.red;
    }
    public void ResetQuiz()
    {
        continueButton.gameObject.SetActive(false);
        ResetButtons();
    }
    private void ResetButtons()
    {

        foreach (var item in answerButtons)
        {
            item.interactable = true;
            item.image.color = new Color(255, 234, 220);
        }
    }
}
