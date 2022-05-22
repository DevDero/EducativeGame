using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UserAction : MonoBehaviour
{
    private Image image;
    protected GameObject label;
    protected bool isActionValidated;
    protected int repetition;
    protected RangeInt percantage=new RangeInt(1,100);

    protected virtual int RepetitionGoal { get; set; }

    private void OnEnable()
    {
        CheckButtonStatus();
    }

    public virtual void AddAction()
    {
        if(ActionList.UserActionList.Count==0)
        {
            CheckGoal();
            ActionList.UserActionList.Add(this);
        }
        else
        {
            var analyser = ActionList.UserActionList.Last();
          
            if (analyser.GetType() == this.GetType())
            {
                analyser.repetition++;
                analyser.CheckGoal();
            }
            else
            {
                CheckGoal();
                ActionList.UserActionList.Add(this);
            }
        }
    }
    public virtual void CreateLabel(Transform content)
    {
        GameObject.Instantiate<GameObject>(label, content);

    }
    public virtual void CheckGoal()
    {
        if (RepetitionGoal != repetition)
            Debug.Log("A goal not meet"); 
    }
    public virtual void CheckButtonStatus()
    {

    }
 

}
