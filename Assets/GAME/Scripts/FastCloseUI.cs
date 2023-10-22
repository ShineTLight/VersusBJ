using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastCloseUI : MonoBehaviour
{
    public PopUpManager _popUpManager;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            _popUpManager.HideTrumpCardPopup();
        }
    }
}
