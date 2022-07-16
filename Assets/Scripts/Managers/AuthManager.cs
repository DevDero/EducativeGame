using Newtonsoft.Json;
using TMPro;
using UnityEngine;

public class AuthManager : MonoBehaviour
{
    private string uid;

    public TMP_InputField name;
    public TMP_InputField emailInputField;
    public TMP_InputField passwordInputField;
    public TextMeshProUGUI outputText;

    void Start()
    {
        FirebaseAuth.OnAuthStateChanged(gameObject.name, "DisplayUserInfo", "DisplayAuthChange");
    }
    public void CreateUserWithEmailAndPassword() =>
           FirebaseAuth.CreateUserWithEmailAndPassword(emailInputField.text, passwordInputField.text, "AuthManager", "DisplayInfo", "DisplayErrorObject");
    public void SignInWithEmailAndPassword() =>
        FirebaseAuth.SignInWithEmailAndPassword(emailInputField.text, passwordInputField.text, "AuthManager", "DisplayInfo", "DisplayErrorObject");

    private void CheckUser(string uid)
    {
        FirebaseDatabase.GetJSON("users/" + uid, "AuthManager", "CreateNewUser", "DisplayErrorObject");
    }
    private void AuthSuccesfull(string info)
    {
        GeneralManager.Instance.LoadSingleSceneAsync("MapScene");
    }

    private void CreateNewUser(string currentData)
    {
        if(currentData == null || currentData == "null" || currentData == "" )
        {
            var localUserData = GeneralManager.Instance.localUserData;
            localUserData.username = name.text;
            localUserData.uid = uid;

                var userDataTemplate = JsonConvert.SerializeObject(localUserData);
            FirebaseDatabase.SetJSON("users/" + uid, userDataTemplate, gameObject.name, "AuthSuccesfull", "DisplayErrorObject");
        }
        else
        {
            Debug.Log("UserExists!");
            try
            {
                var existingdata = JsonConvert.DeserializeObject<LocalUserData>(currentData);
                GeneralManager.Instance.localUserData = existingdata;
                Debug.Log(existingdata+"existingdata");
                AuthSuccesfull(JsonConvert.SerializeObject(GeneralManager.Instance.localUserData));

            }
            catch
            {
                Debug.Log("corrupt data");
            }
           
        }
    }   
    private void DisplayAuthChange(string info)
    {
        outputText.color = Color.red;
        outputText.text = info;
        Debug.Log(info);
    }
    private void DisplayInfo(string info)
    {
        outputText.color = Color.white;
        outputText.text = info;
        Debug.Log(info);
    }
    private void DisplayUserInfo(string user)
    {
        outputText.color = Color.green;
        FirebaseUser info = JsonUtility.FromJson<FirebaseUser>(user);
        outputText.text = info.ShowInfo();
        uid = info.uid;
        CheckUser(uid);

    }
    private void DisplayErrorObject(string error)
    {
        var parsedError = error;
        DisplayError(parsedError);
    }
    private void DisplayError(string error)
    {
        outputText.color = Color.red;
        outputText.text = error;
        Debug.LogError(error);
    }

}
