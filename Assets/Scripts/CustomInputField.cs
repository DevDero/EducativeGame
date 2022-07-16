using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CustomInputField : TMP_InputField
{


    protected override void OnEnable()
    {
        if (Application.isMobilePlatform)
        {
            shouldHideMobileInput = false;
            shouldHideSoftKeyboard = false;

        }
        else
        {
            shouldHideMobileInput = true;
            shouldHideSoftKeyboard = true;
        }

    }
}
