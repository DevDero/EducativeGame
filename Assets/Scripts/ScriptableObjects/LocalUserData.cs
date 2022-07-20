using Newtonsoft.Json;
using System;
using UnityEngine;

//[CreateAssetMenu(fileName = "Level", menuName = "ScriptableObjects/LocalUserData", order = 3)]
public static class LocalUserData 
{
    public static LevelData[] levelDatas = new LevelData[2];
    public static String username;
    public static int totalScore;
    public static string uid;
    public static bool Synced;

    public static void InitLevelDatas()
    {
        levelDatas[0] = new LevelData(0, 00, PlayStatus.Locked);
        levelDatas[1] = new LevelData(0, 01, PlayStatus.Locked);
        totalScore = 0;
    }

    public static void UpdateLocalScoreData(UserData userData)
    {
        levelDatas = userData.scoreData.levelDatas;
        totalScore = userData.scoreData.totalScore;
    }
    public static string LocalScoreDataToJson()
    {
        UserData tempData = new UserData(totalScore, levelDatas);

        return JsonConvert.SerializeObject(tempData);
    }

    public static bool CompareValeus(int level,int value)
    {
        Debug.Log(levelDatas[level].EndLevelPoint+"levelpoint");
        Debug.Log(value+"val");
        Debug.Log(levelDatas[level].EndLevelPoint < value);
        if (levelDatas[level].EndLevelPoint < value)
        {
            Debug.Log(level + "level in compareval");

            levelDatas[level].EndLevelPoint = value;
            CalculateTotalScore();
            return true;

        }
        return false;
    }
    public static void CalculateTotalScore()
    {
        int localtotal = 0;
        foreach (var data in levelDatas)
        {
            Debug.Log(data.EndLevelPoint + "point");

            localtotal += data.EndLevelPoint;
        }
        totalScore = localtotal;
    }
    
}

[Serializable]
public class LevelData
{
    public int EndLevelPoint = 0;
    public PlayStatus playStatus = PlayStatus.Locked;

    public LevelData(int endLevelPoint, int levelCode, PlayStatus status)
    {
        EndLevelPoint = endLevelPoint;
        playStatus = status;
    }
}
[Serializable] public enum PlayStatus { Locked, Unlocked, FirstPlay, RePlay, ReRun, }


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