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
}

public enum TrumpEffect
{
    IncreaseBet,
    Shield,
    DrawSpecific,
    ReturnLastCardSelf,
    ReturnLastCardOpponent
}
