[System.Serializable]
public class UserData
{

    public float totalPoint;
    public LevelData[] levelDatas;
    public string username;    

    public UserData()
    { 
    }
    public UserData(float totalPoint, LevelData[] levelDatas, string name)
    {
        this.totalPoint = totalPoint;
        this.levelDatas = levelDatas;
        this.username = name;
    }

}
