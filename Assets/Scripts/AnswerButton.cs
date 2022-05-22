using TMPro;
using UnityEngine.UI;
using UnityEngine;

[ExecuteInEditMode]
public class AnswerButton : Button
{
    public TextMeshProUGUI answerTMP { get; set; }
    protected override void Awake()
    {
        answerTMP = GetComponentInChildren<TextMeshProUGUI>();
    }
}
