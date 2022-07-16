using Newtonsoft.Json;
using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "ScriptableObjects/LocalUserData", order = 3)]
public class LocalUserData : ScriptableObject
{
    public LevelData[] levelData;
    public String username;
    public int totalScore;
    public string uid;
    public bool Synced;

    public void UpdateLocalUserData(UserData userData)
    {
        this.levelData = userData.levelDatas;
        this.username = userData.username;
        this.totalScore = (int)userData.totalPoint;
    }

    public bool CompareValeus(int level,float value)
    {
        if (levelData[level].EndLevelPoint > value)
        {
            levelData[level].EndLevelPoint = value;
            CalculateTotalScore();
        }
        return false;
    }
    public void CalculateTotalScore()
    {
        int localtotal = 0;
        foreach (var data in levelData)
        {
            data.EndLevelPoint += localtotal;
        }
        totalScore = localtotal;
    }

}

[Serializable]
public class LevelData
{
    public float EndLevelPoint = -1;
    public PlayStatus playStatus;

    public LevelData(float endLevelPoint, int levelCode, PlayStatus status)
    {
        EndLevelPoint = endLevelPoint;
        playStatus = status;
    }
}
[Serializable] public enum PlayStatus { FirstPlay, RePlay, ReRun, Locked ,Unlocked}


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