using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

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
        foreach (UserAction item in ActionList.UserActionList)
        {
            item.WriteLabels(content, item);
        }

        GameObject go = GameObject.Find("Canvas/PopUps/EndLevel/EndLevelElement/TotalScore/_TotalScore");

        go.GetComponent<TextMeshProUGUI>().text = CalculateScore();
    }
    public string CalculateScore()
    {
        float totalScore = 0;

        foreach (var label in content.GetComponentsInChildren<ActionLabel>())
        {
            totalScore += label.score;
        }
        totalScore =
        (int)totalScore;
        return totalScore.ToString();
    }
}

