[System.Serializable]
public class UserData
{
    public UserIntrinsicData intrinsicData = new UserIntrinsicData();
    public ScoreData scoreData = new ScoreData();

    public bool Synced = true;

    public UserData()
    {
        scoreData.levelDatas[0] = new LevelData(0, 00, PlayStatus.Locked);
        scoreData.levelDatas[1] = new LevelData(0, 01, PlayStatus.Locked);
        scoreData.totalScore = 0;
    }
    public UserData(int totalPoint, LevelData[] levelDatas)
    {
        scoreData.totalScore = totalPoint;
        scoreData.levelDatas = levelDatas;
    }
    public UserData(int totalPoint, LevelData[] levelDatas, string name,string uid)
    {
        scoreData.totalScore = totalPoint;
        scoreData.levelDatas = levelDatas;
        intrinsicData.username = name;
        intrinsicData.uid = uid;
    }

}
[System.Serializable]   
public class UserIntrinsicData
{
    public string username;
    public string uid;
}
[System.Serializable]
public class ScoreData
{
    public LevelData[] levelDatas = new LevelData[2];
    public int totalScore;
}
