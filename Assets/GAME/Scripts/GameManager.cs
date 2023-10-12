using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Deck deck;
    public Canvas drawCanvas;

    private bool isPlayerTurn = true;
    
    private List<NumberedCard> playerHand = new List<NumberedCard>();
    private List<NumberedCard> aiHand = new List<NumberedCard>();
    
    private bool playerChoseToStay = false;
    private bool aiChoseToStay = false;

    private void Start()
    {
        drawCanvas.enabled = false;
    }

    private void Update()
    {
        if (isPlayerTurn && Input.GetKeyDown(KeyCode.E))
        {
            NumberedCard drawnCard = (NumberedCard)deck.DrawCard()[0];
            playerHand.Add(drawnCard);
            
            playerChoseToStay = false;
            
            EndPlayerTurn();
            StartAITurn();
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            playerChoseToStay = true;
            
            EndPlayerTurn();
            StartAITurn();
        }
    }
    
    private void EndRound()
    {
        int playerScore = CalculateHandValue(playerHand);
        int aiScore = CalculateHandValue(aiHand);

        if (playerScore > 21 || (aiScore <= 21 && aiScore > playerScore))
        {
            Debug.Log("You've Lost");
        }
        else
        {
            Debug.Log("You Win");
        }
    }
    
    private int CalculateHandValue(List<NumberedCard> hand)
    {
        int total = 0;
        foreach (NumberedCard card in hand)
        {
            total += card.Value;
        }
        return total;
    }

    public void StartPlayerTurn()
    {
        isPlayerTurn = true;
        drawCanvas.enabled = true;
        
        if (playerChoseToStay && aiChoseToStay)
        {
            EndRound();
        }
        else
        {
            Debug.Log("Your Turn");
        }
    }

    public void EndPlayerTurn()
    {
        isPlayerTurn = false;
        drawCanvas.enabled = false;
        Debug.Log("Their Turn");
    }
    
    private void StartAITurn()
    {
        int aiScore = CalculateHandValue(aiHand);
    
        if (aiScore < 17)
        {
            NumberedCard drawnCard = (NumberedCard)deck.DrawCard()[0];
            aiHand.Add(drawnCard);
            
            aiChoseToStay = false;
        }
        else
        {
            aiChoseToStay = true;
        }

        EndAITurn();
        StartPlayerTurn();
    }
    
    private void EndAITurn()
    {
        isPlayerTurn = false;
    }
}
