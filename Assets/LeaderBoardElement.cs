using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LeaderBoardElement : MonoBehaviour
{
    public TextMeshProUGUI username;
    public TextMeshProUGUI score;

    public void SetElement(string _username ,int _score)
    {
        username.text = _username;

        score.text = _score.ToString();
    }
}
