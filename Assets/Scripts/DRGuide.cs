using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DRGuide : MonoBehaviour
{
    private void Awake()
    {
        if (true)   //GET USER DATA INSTANCE 
            ConversationManager.Instance.StartConversation();
    }
}
