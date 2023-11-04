using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool isAI = false;
    
    public int health = 5;
    public int damageModifier = 1;
    public int damageProtection = 0;

    public List<NumberedCard> hand = new List<NumberedCard>();
    public List<TrumpCardData> trumpCardInventory = new List<TrumpCardData>();

    public InventoryUI InventoryUI;
    
    public void AddCardToInventory(TrumpCard card)
    {
        trumpCardInventory.Add(card.cardData);

        if (!isAI)
        {
            InventoryUI.UpdateInventoryDisplay(trumpCardInventory);
        }
    }
    
    public void TakeDamage(int amount)
    {
        int damage = amount - damageProtection;
        health -= Mathf.Max(damage, 0);
        
        ResetModifiers();
    }

    private void ResetModifiers()
    {
        damageModifier = 1;
        damageProtection = 0;
    }

    public void AddCardToHand(NumberedCard card)
    {
        hand.Add(card);
    }

    public void RemoveLastCardFromHand()
    {
        if(hand.Count > 0)
        {
            hand.RemoveAt(hand.Count - 1);
        }
    }
}
