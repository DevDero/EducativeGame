using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DRGuide : MonoBehaviour
{
    [SerializeField]LevelContainer container;
    private void Awake()
    {
        if (container.levelData[0].locked)
            ConversationManager.Instance.StartConversation();
    }
}
