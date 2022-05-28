using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : PopUps
{
    [SerializeField] GameObject content;
    public override Action OnActivation { get => SetLabelList; }

    private void SetLabelList()
    {
        foreach (var item in ActionList.UserActionList)
        {
            Debug.Log("büdü"+ ActionList.UserActionList.Count);

            item.CreateLabel(content.transform);
        }
    }
}
