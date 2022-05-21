using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpManager : MonoBehaviour
{
    public static PopUpManager Instance;
    [SerializeField] public static GameObject restart, ambulance, popquiz, warning, tips, endlevel;
    public enum Popups { restart, popquiz, warning , ambulance ,endlevel }
    


    private void OnEnable()
    {
        Instance = this;
        restart = gameObject.transform.GetChild(0).gameObject;
        popquiz = gameObject.transform.GetChild(1).gameObject;
        warning = gameObject.transform.GetChild(2).gameObject;
        tips = gameObject.transform.GetChild(3).gameObject;
        ambulance= gameObject.transform.GetChild(4).gameObject;
        endlevel = gameObject.transform.GetChild(5).gameObject;
    }
    public void OpenTip(string tip)
    {
        tips.SetActive(true);
        tips.GetComponent<TipPopUp>().text.text = tip;
    }
    public void OpenQuiz()
    {
        
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

