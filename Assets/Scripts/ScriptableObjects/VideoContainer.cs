
using UnityEngine;
using UnityEngine.Video;

[CreateAssetMenu(fileName = "VideoContainer", menuName = "ScriptableObjects/SpawnVideoContainer", order = 1)]
public class VideoContainer : ScriptableObject
{
    public VideoSequence[] videoSequences;
}

[System.Serializable]
public class VideoSequence
{
    public VideoClip VideoClip;
    public SkipPartition[] skipPartition;
}

[System.Serializable]
public class SkipPartition
{
    public string NameOfPartition;

    public double startPartition;
    public double endPartition;

}