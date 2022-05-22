using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GeneralManager : MonoBehaviour
{
    public static GeneralManager Instance;
    private int currentLevel;

    public int CurrentLevel { get => currentLevel;}

    private void Awake()
    {
         Instance = this;
    }

    public void Teleport()
    {
        SceneManager.UnloadSceneAsync("MapScene", UnloadSceneOptions.None);
        SceneManager.LoadSceneAsync("level1", LoadSceneMode.Single);
        
    }
    public void ReturnToCorridor()
    {
        SceneManager.UnloadSceneAsync("level1", UnloadSceneOptions.None);
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MapScene", LoadSceneMode.Single);
    }
    public void RestartLevel()
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        SceneManager.LoadSceneAsync("level1", LoadSceneMode.Single);
    }
    public void OpenDialogueBox()
    {
        //PopUpManager.OpenPopUp();         //TODO ?mplement new managersys
    }
    public void StopConversation()
    {
        ConversationManager.Instance.StopConversation();
    }
    public void OpenActionMenu()
    {
        ActionButtonManager.Instance.ShowActionMenu();
    }
    public void ObligatedBreathControl()
    {
        ActionButtonManager.Instance.DelayedObligatedBreathControl();
    }
    public void DisableConversationButtona()
    {
        ConversationManager.Instance.DisableButtons();
    }
}
