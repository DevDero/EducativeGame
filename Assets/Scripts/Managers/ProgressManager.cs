using System;
using System.Collections;
using UnityEngine;

public class ProgressManager : MonoBehaviour
{
    public static ProgressManager Instance;
    public Patient patient;
  
    private void Awake()
    {
        Instance = this;
    }
    


}

