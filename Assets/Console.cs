using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Console : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void CreateNewUserData()
    {

        UserData newUser = new UserData("anonimuser" , "000000000000");
        LocalUserData.InjectLocalUserData(newUser);
    }
    public void TryValue() =>
    //         levels.TryGetValue("CPR", out LevelData currentLevelData);
        LocalUserData.CurrentLevel();
}
