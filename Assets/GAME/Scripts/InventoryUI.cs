using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class InventoryUI : MonoBehaviour
{
    //Connections
    [SerializeField] private GameObject descriptionPanel;
    [SerializeField] private TextMeshProUGUI cardNameText;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private GameObject trumpCardInventoryUI;
    [SerializeField] private RectTransform frame;
    
    
    public List<InventorySlot> inventorySlots;
    
    public InventorySlot selectedSlot;

    private int currentIndex = 0;

    private void Start()
    {
        currentIndex = 0;
        MoveFrame(0);
        trumpCardInventoryUI.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            trumpCardInventoryUI.SetActive(!trumpCardInventoryUI.activeSelf);
            currentIndex = 0;
            MoveFrame(0);
        }

        if (trumpCardInventoryUI.activeSelf)
        {
            HandleNavigation();
        }
    }
    
    public void UpdateInventoryDisplay(List<TrumpCardData> trumpCards)
    {
        for (int i = 0; i < trumpCards.Count; i++)
        {
            if (i < inventorySlots.Count)
            {
                inventorySlots[i].AddCard(trumpCards[i]);
            }
        }
    }
    
    private void HandleNavigation()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveFrame(-1);
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveFrame(1);
        }
        else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            MoveFrame(-4);
        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            MoveFrame(4);
        }
    }
    
    private void MoveFrame(int direction)
    {
        currentIndex += direction;
        
        if (currentIndex < 0)
        {
            currentIndex = inventorySlots.Count - 1;
        }
        else if (currentIndex >= inventorySlots.Count)
        {
            currentIndex = 0;
        }
        
        frame.DOMove(inventorySlots[currentIndex].transform.position, 0.15f);
        selectedSlot = inventorySlots[currentIndex];

        if (selectedSlot.cardData != null)
        {
            descriptionPanel.SetActive(true);
            ShowDescription();
        }
        else
        {
            descriptionPanel.SetActive(false);
        }
    }

    private void ShowDescription()
    {
        cardNameText.text = selectedSlot.cardData.cardName;
        descriptionText.text = selectedSlot.cardData.description;
    }
}
