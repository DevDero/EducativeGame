using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndLevel : PopUps
{
    public override Action OnActivation { get => scroller.SetLabelList;  }
    [SerializeField] ActionLabelScroller scroller;
    [SerializeField] TMPro.TextMeshProUGUI InfoBox;

   


}
