using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "ScriptableObjects/SpawnLevelElement", order = 3)]
public class LevelContainer : ScriptableObject
{  
    public LevelData[] levelData;
}

[Serializable]
public class LevelData
{
    public float EndLevelPoint;
    public int levelCode;
    public PlayCase Case;
    public bool locked;
}
[Serializable] public enum PlayCase { FirstPlay, RePlay, ReRun }


