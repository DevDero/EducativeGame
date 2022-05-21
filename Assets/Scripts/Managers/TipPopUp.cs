using TMPro;
using UnityEngine;

public class TipPopUp : MonoBehaviour
{
   public TextMeshProUGUI text;

    private void OnEnable()
    {
        Invoke("DisableObject", 6f);
    }
    public void DisableObject()
    {
        gameObject.SetActive(false);
    }

}

