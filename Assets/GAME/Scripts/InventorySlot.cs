using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    private TrumpCardData cardData;

    public void AddCard(TrumpCardData newCard)
    {
        cardData = newCard;

        icon.sprite = cardData.cardArt;
        icon.enabled = true;
    }

    public void ClearSlot()
    {
        cardData = null;
        icon.sprite = null;
        icon.enabled = false;
    }
}
