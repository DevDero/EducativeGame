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
        }

        GetHighScores();
        SetOwnPoint();
    }

    public void SetOwnPoint()
    {
        Debug.Log(lbElement);
        Debug.Log(LocalUserData.localUserIntrinsicData.username);
        Debug.Log(LocalUserData.localLevelData.totalScore);
        lbElement.SetElement(LocalUserData.localUserIntrinsicData.username, LocalUserData.localLevelData.totalScore);
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
        if (Time.unscaledTime > LocalUserData.RefreshHighScoreTime) 
            FirebaseDatabase.GetHighScore(gameObject.name, "Recived", "Failed");
    }
    public void CreateLeaderBoardElement(string _username, int _score,int _rank)
    {
        var element = GameObject.Instantiate(lbElement, content);
        element.SetElement(_username, _score , _rank);
    }
    public void Recived(string snapShot)
    {
        Dictionary<string, UserData> userData = JsonConvert.DeserializeObject<Dictionary<string, UserData>>(snapShot);

        LocalUserData.HighScoreData = userData;

        ResizeContentTab(CalculateHeight(180 + 30,
            userData.Count));//spacing height and offset

        Debug.Log(userData);
        int current = 1;
        for (int i = userData.Count - 1; i > 0; i--) 
        {
            var value = userData.ElementAt(i).Value;

            string name = value.intrinsicdata.username;
            int score = value.leveldata.totalScore;
            CreateLeaderBoardElement(name, score, current);
            current++;
        }
    }
    public void Failed()
    {
        Debug.LogError("Failed to retrieve scoreboard data");
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
