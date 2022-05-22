using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : PopUps
{
    [SerializeField] GameObject content;
    private void Awake()
    {
        ActionList.UserActionList[0].CreateLabel(content.transform);
    }
    private void CalculatePts()
    {

    }
    public void AMCIK()
    {

    }
}
