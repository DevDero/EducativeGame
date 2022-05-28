using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class UserActionButton : Button
{
    [SerializeField] public UserAction action;

    protected override void OnEnable()
    {
        if (action != null)
        {
            action.CheckButtonStatus(this);
        }
    }
}

#if UNITY_EDITOR_WIN
[CustomEditor(typeof(UserActionButton))]
public class UIButtonEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        UserActionButton t = (UserActionButton)target;
    }
}
#endif


//[CustomEditor(typeof(UserActionButton))]
//public class MenuButtonEditor : Editor
//{
//    public override void OnInspectorGUI()
//    {
//        UserActionButton targetMenuButton = (UserActionButton)target;

//        targetMenuButton.action = EditorGUILayout.ObjectField(targetMenuButton.action, typeof(UserAction),true) as UserAction;
//        // Show default inspector property editor
//        DrawDefaultInspector();
//    }
//}
