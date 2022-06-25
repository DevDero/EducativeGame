using UnityEngine;

public class ActionConstraint
{
    string suggestionText;
    public enum OrderType { before, after };

    public delegate void ResponseToConstraint();

    public virtual void CheckConstraint()
    {
        
    }
    public virtual void CheckConstraint(ResponseToConstraint response)
    {

    }
}
