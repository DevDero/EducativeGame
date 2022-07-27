using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] GameObject doorOpen ,doorClosed;

    public void UnlockDoor()
    {
        if (doorClosed)
            doorClosed.SetActive(false);
        if (doorOpen)
            doorOpen.SetActive(true);
    }
    public void LockDoor()
    {
        if (doorClosed)
        doorClosed.SetActive(true);
        if (doorOpen)
        doorOpen.SetActive(false);
    }
}
