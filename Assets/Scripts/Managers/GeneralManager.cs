using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GeneralManager : MonoBehaviour
{
    [SerializeField] GameObject CrossPanel;
    public static GeneralManager Instance;
    [SerializeField] public LocalUserData localUserData;
    /// <summary>
    /// -1 for not a playable state.
    /// </summary>
    private int currentLevel;
    public int CurrentLevel { get => currentLevel;}


    private string currentScene;
    public bool hasPaused { get; set; } = false;
    private float levelTime;
    public float LevelTime { get => levelTime; set => levelTime = value; }

    string VideoScene = ("VideoScene");
    string Level0 = ("level0");
    string Level2 = ("level2");
    string MapScene = ("MapScene");
    string LoginScene = ("LoginScene");
    
    private void Awake()
    {
        DontDestroyOnLoad(this);
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
        AsyncOperation level0LoadOp = SceneManager.LoadSceneAsync(Level0, LoadSceneMode.Single);
        SceneManager.LoadSceneAsync("VideoScene", LoadSceneMode.Additive);
        level0LoadOp.completed += delegate {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(Level0));
        };
    }
    public void LoadSingleSceneAsync(string scene)
    {
        switch (scene)
        {
            case "level0":
                currentLevel = 0;
                break;
            case "level1":
                currentLevel = 1;
                break;
            default:
                currentLevel = -1;
                break;
        }
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        SceneManager.LoadSceneAsync(scene, LoadSceneMode.Single);
    }

    public void RestartLevel()
    {
        Scene _activeScene = SceneManager.GetActiveScene();
        SceneManager.UnloadSceneAsync(_activeScene);
        SceneManager.LoadSceneAsync(_activeScene.name, LoadSceneMode.Single);
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
    public void OpenDoor(int levelNumber)
    {
        ProgressManager.Instance.OpenDoor(levelNumber);
    }
 
}
