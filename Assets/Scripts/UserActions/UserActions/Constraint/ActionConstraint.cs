using UnityEngine;

public abstract class ActionConstraint
{
    string suggestionText;
    public enum OrderType { before, after, ever };

    public delegate void ResponseToConstraint();

    public abstract bool CheckConstraint();

    public abstract bool CheckConstraint(out UserAction actionOfInterest);

    public abstract void CheckConstraint(ResponseToConstraint response);

}
