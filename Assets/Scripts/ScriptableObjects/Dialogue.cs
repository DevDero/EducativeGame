
using System;
using UnityEngine;
using UnityEngine.Video;

[CreateAssetMenu(fileName = "Dialogue", menuName = "ScriptableObjects/SpawnDialogue", order = 2)]
public class Dialogue : ScriptableObject
{
    public DialogueQAPair[] dialogueQAPairs;
}


[Serializable]
public class DialogueGuide
{
    public string[] text;
}

[Serializable]
public class DialogueQAPair
{
    public string question;
    public Answer[] answers;
    public string clue;
}