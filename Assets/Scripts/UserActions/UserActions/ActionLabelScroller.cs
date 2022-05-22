using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

[CustomEditor(typeof(ActionLabelScroller))]
public class ActionButtonScroller : Editor
{
    //    //public override void OnInspectorGUI()
    //    //{
    //    //    base.OnInspectorGUI();
    //    //    ActionLabelScroller scroller = (ActionLabelScroller)target;
    //    //    scroller.labels = EditorGUILayout.ObjectField(scroller.labels, typeof(GameObject), true);
    //    //}
}



public class ActionLabelScroller : ScrollRect
{
    public ActionLabel[] labels;

    public void InstantiateLabels()
    {
        foreach (var action in ActionList.UserActionList)
        {

        }
    }

    public float CalculateHeight(float itemSizePX,int itemAmount)
    {
        return itemSizePX * itemAmount;

    }
    public void  ResizeContentTab(float height)
    {
        content.sizeDelta = new Vector2(0, height);
    }
   
}

