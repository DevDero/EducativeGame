using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : PopUps
{
    [SerializeField] GameObject content;
    public override Action OnActivation { get => CalculatePts; }

    private void Awake()
    {
    }
    private void CalculatePts()
    {

        foreach (var item in ActionList.UserActionList)
        {
            item.CreateLabel(content.transform);
        }
    }
}
