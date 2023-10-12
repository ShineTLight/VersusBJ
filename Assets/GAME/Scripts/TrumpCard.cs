using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TrumpCard : MonoBehaviour
{
    public TrumpEffect effect;
    
    public string Description { get; private set; }

    [SerializeField] private TMP_Text effectText;
    [SerializeField] private GameObject uniqueVisual;

    public void Initialize(string description)
    {
        Description = description;
        uniqueVisual.SetActive(false);
        effectText.text = Description;
    }

    public void RevealEffect()
    {
        uniqueVisual.SetActive(true);
        effectText.gameObject.SetActive(true);
    }
    
    public void ApplyEffect(Player player, Player opponent, Deck deck)
    {
        switch (effect)
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
