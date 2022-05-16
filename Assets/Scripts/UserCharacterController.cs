using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserCharacterController : MonoBehaviour
{
    [SerializeField] GameObject[] poses;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchPose(string poseName)
    {
        foreach (var item in poses)
        {
            item.gameObject.SetActive(false);
        }


        switch (poseName)
        {
            case "Standing":
                poses[0].SetActive(true);
                break;
            case "Nefes":
                poses[1].SetActive(true);
                break;
            case "Crouch":
                poses[2].SetActive(true);
                break;
            case "CPR":
                poses[3].SetActive(true);
                break;
        }
    }
}
