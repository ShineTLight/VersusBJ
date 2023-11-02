using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Deck deck;
    public Canvas drawCanvas;
    public GameObject trumpCardInventoryUI;
    
    public Player player;
    public Player ai;
    
    private bool playerChoseToStay = false;
    private bool aiChoseToStay = false;
    private bool isPlayerTurn = true;

    private void Start()
    {
        drawCanvas.enabled = true;
    }

    private void Update()
    {
        if (isPlayerTurn && Input.GetKeyDown(KeyCode.E))
        {
            var drawnCard = deck.DrawCard();

            foreach (var VARIABLE in drawnCard)
            {
                if (VARIABLE is NumberedCard)
                {
                    player.AddCardToHand((NumberedCard)VARIABLE);
                }
                else if (VARIABLE is TrumpCard)
                {
                    
                }
            }
            
            
            
            playerChoseToStay = false;
            
            EndPlayerTurn();
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            playerChoseToStay = true;
            
            EndPlayerTurn();
        }
    }
    
    private void EndRound()
    {
        int playerScore = CalculateHandValue(player.hand);
        int aiScore = CalculateHandValue(ai.hand);

        if (playerScore > 21 || (aiScore <= 21 && aiScore > playerScore))
        {
            Debug.Log("You've Lost");
            player.TakeDamage(ai.damageModifier);
        }
        else
        {
            Debug.Log("You Win");
            ai.TakeDamage(player.damageModifier);
        }
        
        if(player.health <= 0 || ai.health <= 0)
        {
            GameOver();
        }
        else
        {
            ResetGame();
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
        
        if (playerChoseToStay && aiChoseToStay)
        {
            EndRound();
        }
        else
        {
            Debug.Log("Their Turn");
            StartAITurn();
        }
    }
    
    private void StartAITurn()
    {
        int aiScore = CalculateHandValue(ai.hand);
    
        if (aiScore < 17)
        {
            List<MonoBehaviour> drawnCards = deck.DrawCard();
            
            foreach(var card in drawnCards)
            {
                if(card is NumberedCard)
                {
                    ai.AddCardToHand(card as NumberedCard);
                }
                else if(card is TrumpCard)
                {
                    
                }
            }
            
            drawnCards.Clear();
            aiChoseToStay = false;
        }
        else
        {
            aiChoseToStay = true;
        }

        EndAITurn();
    }
    
    private void EndAITurn()
    {
        if (playerChoseToStay && aiChoseToStay)
        {
            EndRound();
        }
        else
        {
            StartPlayerTurn();
        }
    }
    
    private void GameOver()
    {
        if(player.health <= 0)
        {
            Debug.Log("Game Over! You Lost.");
        }
        else
        {
            Debug.Log("Game Over! You Won!");
        }
    }
    
    private void ResetGame()
    {
        foreach(var card in player.hand)
        {
            Destroy(card.gameObject);
        }
        player.hand.Clear();

        foreach(var card in ai.hand)
        {
            Destroy(card.gameObject);
        }
        ai.hand.Clear();
        
        StartNewRound();
    }
    
    private void StartNewRound()
    {
        deck.ResetDeck();
        playerChoseToStay = false;
        aiChoseToStay = false;
        StartPlayerTurn();
    }
}
