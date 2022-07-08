using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AuthManager : MonoBehaviour
{
    public TMP_InputField emailInputField;
    public TMP_InputField passwordInputField;

    public TextMeshProUGUI outputText;

    // Start is called before the first frame update
    void Start()
    {
        //FirebaseAuth.OnAuthStateChanged(gameObject.name, "DisplayUserInfo", "DisplayInfo");
    }
    public void CreateUserWithEmailAndPassword() =>
           FirebaseAuth.CreateUserWithEmailAndPassword(emailInputField.text, passwordInputField.text, "AuthManager", "DisplayInfo", "DisplayErrorObject");

    public void SignInWithEmailAndPassword() =>
        FirebaseAuth.SignInWithEmailAndPassword(emailInputField.text, passwordInputField.text, gameObject.name, "DisplayInfo", "DisplayErrorObject");

    public void DisplayInfo(string info)
    {
        outputText.color = Color.white;
        outputText.text = info;
        Debug.Log(info);
    }

    public void DisplayErrorObject(string error)
    {
        var parsedError = error;
        DisplayError(parsedError);
    }

    public void DisplayError(string error)
    {
        outputText.color = Color.red;
        outputText.text = error;
        Debug.LogError(error);
    }
}

