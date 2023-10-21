using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject trumpCardInventoryUI;
    public RectTransform frame;
    public List<InventorySlot> inventorySlots;

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
    }
}
