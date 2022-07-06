using System.Collections;
using TMPro;
using UnityEngine;

public class TipPanel : PopUps
{
    [SerializeField] public Animation animation;
    public TextMeshProUGUI _TipTextField;
    public GameObject tipPanel;
    public void ShowTip(string text,float duration)
    {
        _TipTextField.text = text;
        StartCoroutine(DisableObject(duration));
    }
    private IEnumerator DisableObject(float duration)
    {
        while (GeneralManager.Instance.hasPaused) 
            yield return null;

        tipPanel.SetActive(true);
        animation.Play();

        var restingTime = duration;
        while (restingTime > 0)
        {
            restingTime -= Time.deltaTime;
            yield return null;
        }
        tipPanel.SetActive(false);
    }

}

