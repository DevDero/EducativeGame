using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpManager : MonoBehaviour
{
    public static PopUpManager Instance;
    [SerializeField] public static GameObject restart, ambulance, popquiz, warning, tips;

    private void OnEnable()
    {
        Instance = this;
        restart = gameObject.transform.GetChild(0).gameObject;
        popquiz = gameObject.transform.GetChild(1).gameObject;
        warning = gameObject.transform.GetChild(2).gameObject;
        popquiz = gameObject.transform.GetChild(3).gameObject;
        ambulance = gameObject.transform.GetChild(4).gameObject;

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


