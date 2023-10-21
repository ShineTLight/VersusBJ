using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using Image = UnityEngine.UI.Image;

public class TrumpCard : MonoBehaviour
{
    public TrumpCardData cardData;

    public string description;
    public Image displayImage;
    

    public void Initialize(TrumpCardData data)
    {
        cardData = data;
        
        description = data.description;
        displayImage.sprite = data.cardArt;
    }

    public void RevealEffect()
    {
        
    }
    
    public void ApplyEffect(Player player, Player opponent, Deck deck)
    {
        switch (cardData.effect)
        {
            case TrumpEffect.IncreaseBet:
                player.damageModifier += 2;
                break;

            case TrumpEffect.Shield:
                player.damageProtection += 2;
                break;

            case TrumpEffect.DrawSpecific:
                int cardValue = Random.Range(1, 12);
                break;

            case TrumpEffect.ReturnLastCardSelf:
                if (player.hand.Count > 0)
                {
                    deck.ReturnCardToDeck(player.hand[player.hand.Count - 1]);
                    player.RemoveLastCardFromHand();
                }
                break;

            case TrumpEffect.ReturnLastCardOpponent:
                if (opponent.hand.Count > 0)
                {
                    deck.ReturnCardToDeck(opponent.hand[opponent.hand.Count - 1]);
                    opponent.RemoveLastCardFromHand();
                }
                break;
        }
    }
}

public enum TrumpEffect
{
    IncreaseBet,
    Shield,
    DrawSpecific,
    ReturnLastCardSelf,
    ReturnLastCardOpponent
}
