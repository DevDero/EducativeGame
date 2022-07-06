using System;
using System.Collections;
using UnityEngine;

public class ProgressManager : MonoBehaviour
{
    public static ProgressManager Instance;
    private Door[] Doors;
    private LevelData[]levls ;

    private void Awake()
    {
        Instance = this;
    }
    public void OpenDoor(int i)
    {
        Doors[i].UnlockDoor();
    }
}





public class LevelData
{
    public float EndLevelPoint;
    public int levelCode;
    public enum PlayIntention { FirstPlay, RePlay, ReRun }
}

