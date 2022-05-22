using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PopUpManager : MonoBehaviour 
{
    private static PopUpManager Instance;
    [SerializeField]
    private static EndLevel endlevel;
    [SerializeField]
    private static PopUps restart;
    [SerializeField]
    private static Ambulance ambulance;
    [SerializeField]
    private static PopUps warning;
    [SerializeField]
    private static TipPanel tip;
    [SerializeField]
    private static PopQuiz popQuiz;

    public static EndLevel Endlevel { get { return  FindPopUp<EndLevel>(); } }

    public static Ambulance Ambulance { get { return FindPopUp<Ambulance>(); } }

    public static TipPanel Tip { get { return FindPopUp<TipPanel>(); } }

    public static PopQuiz PopQuiz { get { return FindPopUp<PopQuiz>(); } }

    //public static PopUps Restart { get { return FindPopUp<PopUps>(); } }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="Type">Deliver Following PopUp in children</param>
    /// <returns></returns>
    private static TPopUp FindPopUp<TPopUp>()
    {
        return Instance.transform.GetComponentInChildren<TPopUp>();
    }
    private void Awake()
    {
        Instance = this;
    }

}
public class hede
{
}
