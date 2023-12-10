using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NavigationUIChange : MonoBehaviour
{
    //WASD
    [SerializeField] private Sprite WASD_Key;

    //ARROW KEYS
    [SerializeField] private Sprite ArrowKey;
    
    //SETTINGS
    [SerializeField] private int DestinedTime = 2;
    private Image KeyImage;
    private bool isWASD = true;

    private void OnEnable()
    {
        KeyImage = GetComponent<Image>();
        StartCoroutine(ChangeVisual());
    }

    IEnumerator ChangeVisual()
    {
        while (true)
        {
            yield return new WaitForSeconds(DestinedTime);
            KeyImage.sprite = isWASD ? WASD_Key : ArrowKey;
            isWASD = !isWASD;
        }
        
    }
    
}
