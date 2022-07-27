using System.Collections.Generic;

[System.Serializable]
public class UserData
{
    public UserIntrinsicData intrinsicdata = new UserIntrinsicData();
    public LevelDatas leveldata = new LevelDatas();
    
    public UserData(){}

   
    public UserData(string name, string uid)
    {
        this.leveldata.levels.Add("CPR", new LevelData(0, 01, 0));
        this.leveldata.levels.Add("FutureLevel", new LevelData(0, 02, 0));
        this.leveldata.totalScore = 0;

        this.intrinsicdata.username = name;
        this.intrinsicdata.uid = uid;
    }
    public UserData(UserIntrinsicData intrinsicData, LevelDatas levelData)
    {
        this.intrinsicdata = intrinsicData;
        this.leveldata = levelData;
    }   
}
[System.Serializable]   
public class UserIntrinsicData
{
    public string username;
    public string uid;
}
[System.Serializable]
public class LevelDatas
{
    public Dictionary<string, LevelData> levels = new Dictionary<string, LevelData>();
    public int totalScore;
}
