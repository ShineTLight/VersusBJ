using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopUpManager : MonoBehaviour
{
    public static PopUpManager Instance { get; private set; }
    
    public GameObject trumpCardPopup;
    public TMP_Text cardNameText;
    public TMP_Text cardDescriptionText;
    public Image cardArtImage;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        trumpCardPopup.SetActive(false);
    }

    public void ShowTrumpCardPopup(TrumpCard card)
    {
        var cardData = card.cardData;
        
        cardNameText.text = cardData.cardName;
        cardDescriptionText.text = cardData.description;
        cardArtImage.sprite = cardData.cardArt;

        trumpCardPopup.SetActive(true);
    }

    public void HideTrumpCardPopup()
    {
        trumpCardPopup.SetActive(false);
    }
}
