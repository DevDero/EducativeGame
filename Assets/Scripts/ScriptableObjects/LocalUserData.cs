using Newtonsoft.Json;
using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

//[CreateAssetMenu(fileName = "Level", menuName = "ScriptableObjects/LocalUserData", order = 3)]
public static class LocalUserData 
{
    public static UserIntrinsicData localUserIntrinsicData;
    public static LevelDatas localLevelData;



    private static Dictionary<string, UserData>  scoreData;
    private static float refreshHighScoreTime;

    public static Dictionary<string, UserData> HighScoreData { get => scoreData; set { scoreData = value; refreshHighScoreTime = Time.unscaledTime + 60; } }

    public static float RefreshHighScoreTime { get => refreshHighScoreTime;}

    public static void InjectLocalUserData(UserData userData)
    {
        localLevelData = userData.leveldata;
        localUserIntrinsicData = userData.intrinsicdata;
    }
    public static string LocalUserDataToJson()
    {
        UserData tempUserData = new UserData(localUserIntrinsicData, localLevelData);
        return JsonConvert.SerializeObject(tempUserData);
    }
    public static string LocalLevelDataToJson()
    {
        LevelDatas tempLevelData = localLevelData;
        return JsonConvert.SerializeObject(tempLevelData);
    }

   
    public static void CalculateTotalScore()
    {
        int localtotal = 0;

        for (int i = 0; i < localLevelData.levels.Count; i++)
        {
            LevelData levelData = localLevelData.levels.ElementAt(i).Value;
            localtotal += levelData.endlevelpoint;
        }

        localLevelData.totalScore = localtotal;

    }
    public static LevelData CurrentLevel()
    {
        if (localLevelData.levels.TryGetValue("CPR", out LevelData currentLevelData))                   //TODO: get it from currentLevel Data of general manager
        return currentLevelData;
        else
            Debug.LogWarning("Current scene is not a level and you're trying to reach it!");
        return null;


    }
}

[Serializable]
public class LevelData
{
    public int endlevelpoint = 0;
    public PlayStatus playstatus = PlayStatus.Locked;
    public int levelcode;
    public LevelData(int endLevelPoint, int levelCode, PlayStatus status)
    {
        endlevelpoint = endLevelPoint;
        playstatus = status;
    }
    public bool CompareValeus(int value)
    {

        if (endlevelpoint < value)
        {
            endlevelpoint = value;
            LocalUserData.CalculateTotalScore();
            return true;

        }
        return false;
    }
}
[Serializable] public enum PlayStatus { Locked, Unlocked, FirstPlay, ReRun }


public class CustomScriptableObject<T> : ScriptableObject where T : ScriptableObject
{
    public static T _instance;
    public T GetInstance()
    {
        if (_instance == null)
        {
            _instance = Resources.Load(typeof(T).Name) as T;
        }
        return _instance;
    }
}