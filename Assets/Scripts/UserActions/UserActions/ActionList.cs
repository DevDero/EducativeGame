using System.Collections.Generic;

public static class ActionList
{
    public enum ActionListResult {succes,failed,paused};
    public static List<UserAction> UserActionList = new List<UserAction>();
}

