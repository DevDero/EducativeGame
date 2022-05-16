using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpManager : MonoBehaviour
{
    public static PopUpManager Instance;
    [SerializeField] public static GameObject go;

    private void Awake()
    {
        Instance = this;
        go = gameObject.transform.GetChild(0).gameObject;
    
    }
    public static void OpenPopUp()
    {
        go.SetActive(true);
    }
}


