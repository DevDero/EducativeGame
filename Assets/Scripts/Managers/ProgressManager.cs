using System;
using System.Collections;
using UnityEngine;

public class ProgressManager : MonoBehaviour
{
    public static ProgressManager Instance;
    [SerializeField] private Door[] Doors;

    private void Awake()
    {     
        Instance = this;
    }
    //public void OnEnable()
    //{
    //    SetDoors();
    //}
    //public void SetDoors()
    //{
    //    for (int i = 0; i < GeneralManager.Instance.localUserData.levelData.Length; i++)
    //    {
    //        LevelData level = GeneralManager.Instance.localUserData.levelData[i];

    //        if (level.playStatus == PlayStatus.Locked)
    //            Doors[i].LockDoor();
    //        else
    //            Doors[i].UnlockDoor();
    //    }
    //}
    public void OpenDoor(int i)
    {
        LocalUserData.levelDatas[i].playStatus = PlayStatus.Unlocked;
        Doors[i].UnlockDoor();
    }
}
