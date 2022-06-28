using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GeneralManager : MonoBehaviour
{

    public bool hasPaused { get; set; } = false;
    private float levelTime;
    public float LevelTime { get => levelTime; set => levelTime = value; }

    public static GeneralManager Instance;
    //private int currentLevel;

    //public int CurrentLevel { get => currentLevel;}

    private void Awake()
    {

         Instance = this;
    }
    private void FixedUpdate()
    {
        if(!hasPaused)
        LevelTime += Time.fixedDeltaTime;
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
        ActionList.UserActionList.Clear();
    }
    public void RestartVideoLevel()
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        SceneManager.LoadSceneAsync("VideoScene", LoadSceneMode.Single);
    }
    public void OpenRestartPopUp()
    {
        PopUpManager.RestartPanel.panel.ActivatePanel();
    }
    public void OpenRestartPopUp(string text)
    {
        PopUpManager.RestartPanel.panel.ActivatePanel();
        PopUpManager.RestartPanel.SetText(text);
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
    public void SendAmbulance()
    {
        PopUpManager.AmbulanceItem.panel.ActivatePanelWitchAction();
    }
}
