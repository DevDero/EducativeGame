using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class ActionLabelScroller : ScrollRect
{
    protected override void OnEnable()
    {
        ResizeContentTab(CalculateHeight(300 + 30 ,
            ActionList.UserActionList.Count) + 30);//spacing height and offset

    }
    public float CalculateHeight(float itemSizePX,int itemAmount)
    {
        return itemSizePX * itemAmount;

    }
    public void  ResizeContentTab(float height)
    {
        content.sizeDelta = new Vector2(0, height);
    }

    public void SetLabelList()
    {
        Debug.Log("Label listed " + ActionList.UserActionList.Count + " items");
        
        foreach (UserAction item in ActionList.UserActionList)
        {
            item.WriteLabels(content, item);
        }
    }
}

