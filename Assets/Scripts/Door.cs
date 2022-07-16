using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] GameObject doorOpen ,doorClosed;
    private bool hasUnlocked;
    private bool hadPlayed;

    public void UnlockDoor()
    {
        doorClosed.SetActive(false);
        doorOpen.SetActive(true);
    }
    public void LockDoor()
    {
        doorClosed.SetActive(true);
        doorOpen.SetActive(false);
    }
}
