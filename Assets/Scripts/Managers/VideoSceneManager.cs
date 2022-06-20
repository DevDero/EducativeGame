using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.Video;
using System.Runtime.InteropServices;

public class VideoSceneManager : MonoBehaviour
{
    [SerializeField] VideoPlayer videoPlayer;
    [SerializeField] VideoContainer videocontainer;
    [SerializeField] Button forwardButton, backwardButton, playstop;
    [SerializeField] string[] videoUrls;
    [SerializeField] GameObject mockPlay, videoControllers;
    
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
        videoPlayer.url = videoUrls[0];
        videoPlayer.Play();
    }
    private void Start()
    {
        HTMLButtonCreate("Video Player");
        videoPlayer.loopPointReached += GoToMain;
    }

    public void GoToMain(VideoPlayer vp)
    {
        GeneralManager.Instance.LoadMainMenu();
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
        if (videosCurrentPart < videocontainer.videoSequences[0].skipPartition.Length)
        {
            videoPlayer.time = videocontainer.videoSequences[0].skipPartition[videosCurrentPart].endPartition;
        }
    }
    public void Backward()
    {
        if (videosCurrentPart > 0)
        {
            videoPlayer.time = videocontainer.videoSequences[0].skipPartition[videosCurrentPart - 1].startPartition;
        }
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

    }
}