using System;
using System.Collections;
using UnityEngine;

public class ProgressManager : MonoBehaviour
{
    public static ProgressManager Instance;
    [SerializeField] private Door[] Doors;
    LevelContainer container;

    private void Awake()
    {
        Instance = this;
    }
    public void OpenDoor(int i)
    {
        Doors[i].UnlockDoor();
    }
}
