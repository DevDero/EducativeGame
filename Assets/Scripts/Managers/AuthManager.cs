using Newtonsoft.Json;
using System.Text;
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
           FirebaseAuth.CreateUserWithEmailAndPassword(emailInputField.text, Encoding.ASCII.GetString(PasswordFormat(passwordInputField.text)),
               "AuthManager", "DisplayInfo", "DisplayErrorObject");
    public void SignInWithEmailAndPassword() =>
        FirebaseAuth.SignInWithEmailAndPassword(emailInputField.text, Encoding.ASCII.GetString(PasswordFormat(passwordInputField.text)),
            "AuthManager", "DisplayInfo", "DisplayErrorObject");

    private void CheckUser(string uid)
    {
        FirebaseDatabase.GetJSON("users/" + uid, "AuthManager", "CreateNewUser", "DisplayErrorObject");
    }
    private void AuthSuccesfull()
    {
        GeneralManager.Instance.LoadSingleSceneAsync("MapScene");
    }
    private void CreateNewUser(string currentData)
    {

        if(currentData == null || currentData == "null" || currentData == "" )
        {
            UserData FreshUserData = new UserData(name.text, uid);
            string userDataTemplate = JsonConvert.SerializeObject(FreshUserData);
            FirebaseDatabase.SetJSON("users/" + uid, userDataTemplate, gameObject.name, "AuthSuccesfull", "DisplayErrorObject");
            LocalUserData.InjectLocalUserData(FreshUserData);

        }
        else
        {
            Debug.Log("UserExists!");
            try
            {
                var existingdata = JsonConvert.DeserializeObject<UserData>(currentData);
                LocalUserData.InjectLocalUserData(existingdata);
                AuthSuccesfull();
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

    private byte[] PasswordFormat(string name)
    {
        ASCIIEncoding encoding = new ASCIIEncoding();
        byte[] bytes = encoding.GetBytes(name);
        var sha = new System.Security.Cryptography.SHA1CryptoServiceProvider();
        return sha.ComputeHash(bytes);

    }


}
