using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New TrumpCard", menuName = "TrumpCard")]
public class TrumpCardData : ScriptableObject
{
    public string cardName;
    public string description;
    public Sprite cardArt;
    public TrumpEffect effect;
}