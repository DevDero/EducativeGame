using System;
using System.Collections;
using System.Linq;
using UnityEngine;

public class ProgressManager : MonoBehaviour
{
    public static ProgressManager Instance;
    [SerializeField] private Door[] Doors;

    private void Awake()
    {     
        Instance = this;
    }
    public void OnEnable()
    {
        SetDoors();
    }
    public void SetDoors()
    {
        for (int i = 0; i < LocalUserData.localLevelData.levels.Count; i++)
        {          
            LevelData level = LocalUserData.localLevelData.levels.ElementAt(i).Value;

            if (level.playstatus != PlayStatus.Locked) 
            Doors[i].UnlockDoor();
        }
    }

    public void OpenDoor(int i)
    {
        LocalUserData.localLevelData.levels.ElementAt(i).Value.playstatus = PlayStatus.Unlocked;
        Doors[i].UnlockDoor();
    }
}
