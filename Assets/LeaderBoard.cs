using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class LeaderBoard : ScrollRect
{
    private LeaderBoardElement lbElement;

    protected override void OnEnable()
    {    
        if(lbElement==null)
        {
            lbElement = GameObject.FindObjectOfType<LeaderBoardElement>();
            lbElement.gameObject.SetActive(false);
        }

        GetHighScores();
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
        FirebaseDatabase.GetHighScore(gameObject.name, "Recived", "Failed");
    }
    public void CreateLeaderBoardElement(string _username, int _score)
    {
        var element = GameObject.Instantiate(lbElement, content);
        element.SetElement(_username, _score);
    }
    public void Recived(string snapShot)
    {
        Debug.Log(snapShot);
        Dictionary<string, UserData> userData = JsonConvert.DeserializeObject<Dictionary<string, UserData>>(snapShot);
        Debug.Log("hede");

        ResizeContentTab(CalculateHeight(300 + 30,
            userData.Count) + 30);//spacing height and offset


        for (int i = 0; i < userData.Count; i++)
        {
            var value = userData.ElementAt(i).Value;
            string name = value.intrinsicdata.username;
            int score = value.leveldata.totalScore;

            CreateLeaderBoardElement(name, score);
        }
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
