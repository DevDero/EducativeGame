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
    public string CurrentLevel { get => currentLevel;}

    public bool hasPaused { get; set; } = false;
    private float levelTime;
    public float LevelTime { get => levelTime; set => levelTime = value; }

    string VideoScene = ("VideoScene");
    string Level0 = ("CPR");
    string Level1 = ("Level1");
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

    //private void OnApplicationQuit()
    //{
    //    FirebaseAuth.SignOutUser();
    //}
}
