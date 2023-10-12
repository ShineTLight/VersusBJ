using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NumberedCard : MonoBehaviour
{
    public int Value { get; private set; }

    [SerializeField] private TMP_Text cardNumberText;

    public void Initialize(int value)
    {
        Value = value;
        Display();
    }

    private void Display()
    {
        cardNumberText.text = Value.ToString();
    }
}
