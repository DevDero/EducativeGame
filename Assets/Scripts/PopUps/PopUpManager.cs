using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpManager : MonoBehaviour 
{
    private static PopUpManager Instance;
    [SerializeField]
    private static EndLevel endlevelPanel;
    [SerializeField]
    private static Restart restartPanel;
    [SerializeField]
    private static Ambulance ambulanceItem;
    [SerializeField]
    private static PopUps warningPanel;
    [SerializeField]
    private static TipPanel tipPanel;
    [SerializeField]
    private static PopQuiz popQuizPanel;

    public static EndLevel EndlevelPanel { get { return  FindPopUp<EndLevel>(); } }

    public static Ambulance AmbulanceItem { get { return FindPopUp<Ambulance>(); } }

    public static TipPanel TipPanel { get { return FindPopUp<TipPanel>(); } }

    public static PopQuiz PopQuizPanel { get { return FindPopUp<PopQuiz>(); } }

    public static Restart RestartPanel { get { return FindPopUp<Restart>(); } }

    public static bool PopUpManagerInitialized { get { if (Instance) return true; else return false; } }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="Type">Deliver Following PopUp in children</param>
    /// <returns></returns>
    private static TPopUp FindPopUp<TPopUp>() where TPopUp : PopUps
    {
            return Instance.transform.GetComponentInChildren<TPopUp>();
    }
    private void Awake()
    {
        Instance = this;
    }
}
