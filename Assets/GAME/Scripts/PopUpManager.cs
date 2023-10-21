using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopUpManager : MonoBehaviour
{
    public GameObject popUpCanvas;
    public TextMeshPro cardNameText;
    public TextMeshPro cardDescriptionText;

    public void ShowPopUp(TrumpCardData cardData)
    {
        cardNameText.text = cardData.cardName;
        cardDescriptionText.text = cardData.description;
        popUpCanvas.SetActive(true);
    }

    public void ClosePopUp()
    {
        popUpCanvas.SetActive(false);
    }
}
