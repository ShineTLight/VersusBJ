using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public NumberedCard numberedCardPrefab;
    public TrumpCard trumpCardPrefab;

    private List<int> numberedCardValues = new List<int>();
    private List<string> trumpCardDescriptions = new List<string>();

    private float trumpCardDrawChance = 0.05f;

    private void Start()
    {
        for (int i = 1; i <= 11; i++)
        {
            numberedCardValues.Add(i);
        }
        
        trumpCardDescriptions.Add("Effect 1");
        trumpCardDescriptions.Add("Effect 2");
    }

    public List<MonoBehaviour> DrawCard()
    {
        List<MonoBehaviour> drawnCards = new List<MonoBehaviour>();
        
        NumberedCard nCard = DrawRandomNumberedCard();
        if (nCard != null)
        {
            drawnCards.Add(nCard);
        }
        
        if (Random.value < trumpCardDrawChance)
        {
            TrumpCard tCard = DrawRandomTrumpCard();
            if (tCard != null)
            {
                drawnCards.Add(tCard);
            }
            trumpCardDrawChance = 0.05f;
        }
        else
        {
            trumpCardDrawChance += 0.05f;
        }

        return drawnCards;
    }
    
    private NumberedCard DrawRandomNumberedCard()
    {
        if (numberedCardValues.Count == 0) return null;

        int randomIndex = Random.Range(0, numberedCardValues.Count);
        int drawnValue = numberedCardValues[randomIndex];
        numberedCardValues.RemoveAt(randomIndex);

        NumberedCard newCard = Instantiate(numberedCardPrefab);
        newCard.Initialize(drawnValue);
        return newCard;
    }

    private TrumpCard DrawRandomTrumpCard()
    {
        if (trumpCardDescriptions.Count == 0) return null;

        int randomIndex = Random.Range(0, trumpCardDescriptions.Count);
        string drawnDescription = trumpCardDescriptions[randomIndex];
        trumpCardDescriptions.RemoveAt(randomIndex);

        TrumpCard newCard = Instantiate(trumpCardPrefab);
        newCard.Initialize(drawnDescription);
        return newCard;
    }
    
    public void ReturnCardToDeck(NumberedCard card)
    {
        numberedCardValues.Add(card.Value);
        ShuffleDeck();
    }
    
    private void ShuffleDeck()
    {
        int count = numberedCardValues.Count;
        
        for (int i = 0; i < count - 1; i++)
        {
            int r = Random.Range(i, count);
            int temp = numberedCardValues[i];
            numberedCardValues[i] = numberedCardValues[r];
            numberedCardValues[r] = temp;
        }
    }
    
    public void ResetDeck()
    {
        numberedCardValues.Clear();
        for (int i = 1; i <= 11; i++)
        {
            numberedCardValues.Add(i);
        }
        
        trumpCardDescriptions.Clear();
        trumpCardDescriptions.Add("Effect 1");
        trumpCardDescriptions.Add("Effect 2");
        
        trumpCardDrawChance = 0.05f;
    }
}
