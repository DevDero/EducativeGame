//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.Events;
//using UnityEngine.UI;
//using UnityEngine.Video;

//public class VideoSceneManager : MonoBehaviour
//{
//    [SerializeField] VideoPlayer videoPlayer;
//    [SerializeField] VideoContainer videocontainer;
//    [SerializeField] Button forwardButton,backwardButton,playstop;

//    private int videosCurrentPart;

//    private UnityEvent onVideoFinished;

//    private UnityAction unityAction;

//    private void Update()
//    {
//        GetCurrentPart();
//    }
//    private void Start()
//    {
//        videoPlayer.loopPointReached += GoToMain;
//    }

//    public void GoToMain(VideoPlayer vp)
//    {
//        Debug.Log("hede");
//        GeneralManager.Instance.LoadMainMenu();
//    }
//    public void StartStopVideo()
//    {

//        Debug.Log("videoplayer");
//        videoPlayer.url = "https://reaksiyonyazilim.com/1.mp4";
//        videoPlayer.Play();
//        Debug.Log(videoPlayer.url);
//        Debug.Log("videoplater");

//        //if (videoPlayer.isPlaying)
//        //    videoPlayer.Pause();
//        //else
//        //videoPlayer.Play();
//    }
//    public void Forward()
//    {
//        if (videosCurrentPart < videocontainer.videoSequences[0].skipPartition.Length) 
//        {
//            videoPlayer.time = videocontainer.videoSequences[0].skipPartition[videosCurrentPart].endPartition;
//        }
//    }
//    public void Backward()
//    {
//        if (videosCurrentPart > 0)
//        {
//            videoPlayer.time = videocontainer.videoSequences[0].skipPartition[videosCurrentPart-1].startPartition;
//        }
//    }

//    public void GetCurrentPart()
//    {
    
//        var skippartition = videocontainer.videoSequences[0].skipPartition;

//        for (int i = 0; i < videocontainer.videoSequences[0].skipPartition.Length; i++)
//        {
//            if (videoPlayer.time < skippartition[i].endPartition && videoPlayer.time > skippartition[i].startPartition)
//            {
//                videosCurrentPart = i;
//            }
//        }

//    }
//    private void LoadVideo()
//    {


//    }


//}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoSceneManager : MonoBehaviour
{
    public string url;
    public VideoPlayer vidplayer;

    // Start is called before the first frame update
    void Start()
    {
        vidplayer = GetComponent<VideoPlayer>();
        vidplayer.url = url;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            Play();
        }

    }

    void Play()
    {
        vidplayer.Play();
        vidplayer.isLooping = true;
    }
}
