using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GeneralManager : MonoBehaviour
{

    [SerializeField] GameObject CrossPanel;
    [SerializeField] Scene VideoScene, Level1, Level2, MapScene, LoginScene;
    private string currentScene;
    public bool hasPaused { get; set; } = false;
    private float levelTime;
    public float LevelTime { get => levelTime; set => levelTime = value; }

    public static GeneralManager Instance;
    //private int currentLevel;

    //public int CurrentLevel { get => currentLevel;}

    private void SetScenes()
    {
        VideoScene = SceneManager.GetSceneByName("VideoScene");
        Level1 = SceneManager.GetSceneByName("level1");
        Level2 = SceneManager.GetSceneByName("level2");
        MapScene = SceneManager.GetSceneByName("MapScene");
        LoginScene = SceneManager.GetSceneByName("LoginScene");
    }
    private void Awake()
    {
        var cPanel = GameObject.Instantiate<GameObject>(CrossPanel);
        Object.Destroy(cPanel, 2);
        Instance = this;
    }
    private void FixedUpdate()
    {
        if(!hasPaused)
        LevelTime += Time.fixedDeltaTime;
    }

    public void LoadVideo(string url)
    {
        AsyncOperation level1LoadOp = SceneManager.LoadSceneAsync("level1", LoadSceneMode.Single);
        SceneManager.LoadSceneAsync("VideoScene", LoadSceneMode.Additive);
        level1LoadOp.completed += delegate {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("level1"));
        };
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
    public void DisableConversationButton()
    {
        ConversationManager.Instance.DisableButtons();
    }
    public void SendAmbulance()
    {
        PopUpManager.AmbulanceItem.panel.ActivatePanelWitchAction();
    }
    public void OpenDoor1()
    {
        ProgressManager.Instance.OpenDoor(0);
    }
    public void OpenDoor2()
    {
        ProgressManager.Instance.OpenDoor(1);
    }
}
