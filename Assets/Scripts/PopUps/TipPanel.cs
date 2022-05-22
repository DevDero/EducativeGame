using System.Collections;
using TMPro;
using UnityEngine;

public class TipPanel : MonoBehaviour
{
    public TextMeshProUGUI _TipTextField;

    public void ShowTip(string text,float duration)
    {
        _TipTextField.text = text;

        StartCoroutine(DisableObject(duration));
    
    }
    private IEnumerator DisableObject(float duration)
    {
        var restingTime = duration;
        while (restingTime > 0)
        {
            restingTime = Time.deltaTime;
         
            yield return null;
        }
        gameObject.SetActive(false);
    }

}

