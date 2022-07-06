using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "ScriptableObjects/SpawnLevelElement", order = 3)]
public class LevelContainer : ScriptableObject
{
    public LevelData levelData;
}

