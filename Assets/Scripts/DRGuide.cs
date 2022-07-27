using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DRGuide : MonoBehaviour
{
    [SerializeField] public ConversationSO welcome, welocomehalf, comeback, afterlevel1;
    private bool hasDrAppeared;
    
    private void Awake()
    {
        SetConversation();
    }
    private void SetConversation()          // TODO: Dedicated Conversation Data keeping or elegant conversation managment
    {

        if (LocalUserData.localLevelData.levels["CPR"].playstatus == PlayStatus.Locked)
            ConversationManager.Instance.conversationSO = welcome;
        else if (LocalUserData.localLevelData.levels["CPR"].playstatus == PlayStatus.Unlocked)
            ConversationManager.Instance.conversationSO = welocomehalf;
        else if (LocalUserData.localLevelData.levels["CPR"].playstatus != PlayStatus.Locked ) 
            ConversationManager.Instance.conversationSO = afterlevel1;
        else if (LocalUserData.localLevelData.levels["FutureLevel"].playstatus == PlayStatus.Unlocked && !hasDrAppeared)
            ConversationManager.Instance.conversationSO = comeback;

        if (ConversationManager.Instance.conversationSO != null) 
        ConversationManager.Instance.StartConversation();


    }
}
