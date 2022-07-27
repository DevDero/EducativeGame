using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GeneralManager : MonoBehaviour
{
    [SerializeField] GameObject CrossPanel;
    public static GeneralManager Instance;
    /// <summary>
    /// -1 for not a playable state.
    /// </summary>
    
    private string currentLevel;
    public SceneType currentSceneType;
    public string CurrentLevel { get => currentLevel;}

    public bool hasPaused { get; set; } = false;
    private float levelTime;
    public float LevelTime { get => levelTime; set => levelTime = value; }

    string VideoScene = ("VideoScene");
    string Level0 = ("CPR");
    string Level1 = ("Level1");
    string MapScene = ("MapScene");
    string LoginScene = ("LoginScene");
    
    public enum SceneType { NA ,Level ,Menu }
    private void Awake()
    {
        DontDestroyOnLoad(this);
        FadeIn();
        Instance = this;
        SceneManager.activeSceneChanged += FadeIn;
    }
    private void FadeIn()
    {
        var cPanel = GameObject.Instantiate<GameObject>(CrossPanel);
        Object.Destroy(cPanel, 2);
    }
    private void FadeIn(Scene current, Scene next)
    {
        var cPanel = GameObject.Instantiate<GameObject>(CrossPanel);
        Object.Destroy(cPanel, 2);
    }
    private void FixedUpdate()
    {
        if(!hasPaused && currentSceneType == SceneType.Level)
        LevelTime += Time.fixedDeltaTime;
        if (levelTime > 5 * 60)
            OpenRestartPopUp("5 dakkika geçti, videodaki talimatlara uyun. Acil durumlarda mutlaka 112'ye ulas?n! !"); 
    }

    public void LoadVideo()                                                 // TODO: terminate level dependencies from this method
    {
        AsyncOperation level0LoadOp = SceneManager.LoadSceneAsync(Level0, LoadSceneMode.Single);
        SceneManager.LoadSceneAsync(VideoScene, LoadSceneMode.Additive);
        level0LoadOp.completed += delegate {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(Level0));
            SetCurrentLevel(Level0);
        };
    }
    private void SetCurrentLevel(string scene)               //TODO: get this part procedural embed video URL to video SO and get it with level
    {
        currentLevel = SceneManager.GetActiveScene().name;
        Debug.Log("currentLevel set to" + currentLevel);
    }
    public void LoadSingleSceneAsync(string scene)
    {      
        SceneManager.LoadSceneAsync(scene, LoadSceneMode.Single);
    }
    public void LoadSceneAsync(string scene)
    {
        AsyncOperation loadingScene = SceneManager.LoadSceneAsync(scene, LoadSceneMode.Single);
        loadingScene.completed += delegate {
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(Level0));
            SetCurrentLevel(scene);
        };
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
    }

    public void RestartLevel()
    {
        Scene _activeScene = SceneManager.GetActiveScene();
        
        SceneManager.UnloadSceneAsync(_activeScene);
        SceneManager.LoadSceneAsync(_activeScene.name, LoadSceneMode.Single);

        levelTime = 0;

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
    public void ShowLeaderBoard()
    {
        ConversationManager.Instance.StopConversation();
        ConversationManager.Instance.ShowLeaderBoard();
    }
}
