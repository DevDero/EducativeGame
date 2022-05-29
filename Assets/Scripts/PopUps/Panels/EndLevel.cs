using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : PopUps
{
    public override Action OnActivation { get => scroller.SetLabelList; }
    [SerializeField] ActionLabelScroller scroller;
  
}
