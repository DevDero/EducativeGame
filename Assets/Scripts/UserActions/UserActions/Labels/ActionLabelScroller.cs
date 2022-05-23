using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

//[CustomEditor(typeof(ActionLabelScroller))]
//public class ActionButtonScroller : Editor
//{
//    //    //public override void OnInspectorGUI()
//    //    //{
//    //    //    base.OnInspectorGUI();
//    //    //    ActionLabelScroller scroller = (ActionLabelScroller)target;
//    //    //    scroller.labels = EditorGUILayout.ObjectField(scroller.labels, typeof(GameObject), true);
//    //    //}
//}

public class ActionLabelScroller : ScrollRect
{
    public ActionLabel[] labels;

    protected override void Awake()
    {
        CalculateHeight( 300+30+30 ,ActionList.UserActionList.Capacity); //spacing height and offset
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

