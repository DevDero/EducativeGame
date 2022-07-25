using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.Video;
using System.Runtime.InteropServices;
using UnityEngine.SceneManagement;

public class VideoSceneManager : MonoBehaviour
{
    [SerializeField] VideoPlayer videoPlayer;
    [SerializeField] VideoContainer videocontainer;
    [SerializeField] Button forwardButton, backwardButton, playstop ,escapeButton;
    [SerializeField] string[] videoUrls;
    [SerializeField] GameObject mockPlay, videoControllers;

    public static string CPR = "https://reaksiyonyazilim.com/1.mp4";
    public static string video2 = "";

#if UNITY_WEBGL && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void HTMLButtonCreate(string videoPlayerName);
#else
#pragma warning disable IDE0060
    private void HTMLButtonCreate(string videoPlayerName) { }
    #pragma warning restore IDE0060 
#endif
    private int videosCurrentPart;

    private UnityEvent onVideoFinished;
    private UnityAction unityAction;

    private void Update()
    {
        GetCurrentPart();
    }
    public void InitVideo()
    {
        videoControllers.SetActive(true);    
        mockPlay.SetActive(false);
        videoPlayer.url = "";
        videoPlayer.Play();
        Debug.Log(videoPlayer.url);

    }
    private void Start()
    {
        HTMLButtonCreate(gameObject.name);
        videoPlayer.loopPointReached += GoToLevelScene;
        StartCoroutine(EscapeProcedure());
    }
    public void GoToLevelScene(VideoPlayer vp)
    {
        SceneManager.UnloadSceneAsync("VideoScene");
    }

    public void StartStopVideo()
    {
        if (videoPlayer.isPlaying)
            videoPlayer.Pause();
        else
            videoPlayer.Play();
    }

    public void Forward()
    {
        if (videosCurrentPart < videocontainer.videoSequences[0].skipPartition.Length-1)
        {
            videoPlayer.time = videocontainer.videoSequences[0].skipPartition[videosCurrentPart].endPartition;
        }
        else if(videosCurrentPart == videocontainer.videoSequences[0].skipPartition.Length-1)
            videoPlayer.time = videoPlayer.length - 5;
    }
    public void Backward()
    {
        if (videosCurrentPart > 0)
        {
            videoPlayer.time = videocontainer.videoSequences[0].skipPartition[videosCurrentPart - 1].startPartition;
        }
    }
    public void RestrictButtons(int currentPartition,int totalPartition)
    {
        if (currentPartition == totalPartition)
            forwardButton.interactable = false;
        else if (currentPartition == 0)
            backwardButton.interactable = false;
        else
        {
            forwardButton.interactable = true;
            backwardButton.interactable = true;
        }

    }
    public IEnumerator EscapeProcedure()
    {
            yield return new WaitForSeconds(10);
        if (videoPlayer.isPlaying)
            Debug.Log("video is playing hide escape");
        else
            escapeButton.gameObject.SetActive(true);
            

    }
    public void GetCurrentPart()
    {
        var skippartition = videocontainer.videoSequences[0].skipPartition;

        for (int i = 0; i < videocontainer.videoSequences[0].skipPartition.Length; i++)
        {
            if (videoPlayer.time < skippartition[i].endPartition && videoPlayer.time > skippartition[i].startPartition)
            {
                videosCurrentPart = i;
            }
        }
        RestrictButtons(videosCurrentPart, videocontainer.videoSequences[0].skipPartition.Length);
    }
}