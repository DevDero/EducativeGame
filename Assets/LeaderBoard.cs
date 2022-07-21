using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderBoard : ScrollRect
{
    protected override void OnEnable()
    {
        ResizeContentTab(CalculateHeight(300 + 30,
            ActionList.UserActionList.Count) + 30);//spacing height and offset

    }
    public float CalculateHeight(float itemSizePX, int itemAmount)
    {
        return itemSizePX * itemAmount;

    }
    public void ResizeContentTab(float height)
    {
        content.sizeDelta = new Vector2(0, height);
    }
    public void GetHighScores()
    {
        UserIntrinsicData template = new UserIntrinsicData();
        var userasJSON = JsonUtility.ToJson(template);

        FirebaseDatabase.GetHighScore(gameObject.name, "Recived", "Failed");
    }
    public void Recived(string snapShot)
    {
        Debug.Log(snapShot);
    }
    public void Failed()
    {

    }
    public void SetLabelList()
    {
        foreach (UserAction item in ActionList.UserActionList)
        {
            item.WriteLabels(content, item);
        }

        GameObject go = GameObject.Find("Canvas/PopUps/EndLevel/EndLevelElement/TotalScore/_TotalScore");
    } 
}
