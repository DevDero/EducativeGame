using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarScoreElement : MonoBehaviour
{
    [SerializeField]Image[] Stars;
    public float value;



    /// <summary>
    /// Feed value to fill stars. max input : 3.
    /// </summary>
    /// <returns></returns>
    IEnumerator AnimateStars(float starToFill)
    {
        float valueRest = starToFill;

        
        for (int i = 0; i < Stars.Length;)
        {
            if (valueRest < 0) break;
            Stars[i].GetComponentInParent<Animation>().Play();
            while (Stars[i].fillAmount < 1 && valueRest > 0) 
            {
                Stars[i].fillAmount += 0.01f;
                valueRest -= 0.01f;
                yield return null;
            }
            i++;
        }
    }
    private void OnEnable()
    {
        StartCoroutine(AnimateStars(value));
    }
    
}
