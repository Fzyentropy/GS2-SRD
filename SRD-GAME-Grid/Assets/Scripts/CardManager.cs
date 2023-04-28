using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CardManager: MonoBehaviour
{

    public static CardManager CM;

    public GameObject card;
    public GameObject cardGrid;
    public GameObject cardGridHand;

    public GameObject cardInstanceHolder;


    private void Awake()
    {
        SingletonCardManager();
    }

    void Start()
    {
        // At Start, Instantiate the Player Card Inventory, Get and Show all the cards that player found
        
        
        
    }


    void Update()
    {
        
    }

    // Implementation
    // Singleton Card Manager
    void SingletonCardManager()
    {
        if (CM == null)
        {
            DontDestroyOnLoad(gameObject);
            CM = this;
            Debug.Log("Made Card Manager Singleton.");
        }
        else
        {
            Destroy(gameObject);
            Debug.Log("New Card Manager Destroyed.");
        }
    }
    

    // Implementation
    // Get and Show all the cards that player found
    // Display all the cards in the Inventory List
    public void DisplayInventoryCards()
    {
        
        // TODO Display all the cards in "Inventory"
        foreach (MCard mCardReference in GameManager.GM.cardsInInventory)
        {
            cardInstanceHolder = Instantiate(card, cardGrid.transform);
            cardInstanceHolder.GetComponentInChildren<CardInstance>().mCard = mCardReference;
        }

    }
    
    // Get and Show all the cards in player's hand
    // Display all the cards in player's hand
    public void DisplayHandCards()
    {
        
        // TODO Display all the cards in "Hands"
        foreach (MCard mCardReference in GameManager.GM.cardsInHand)
        {
            cardInstanceHolder = Instantiate(card, cardGridHand.transform);
            cardInstanceHolder.GetComponentInChildren<CardInstance>().mCard = mCardReference;
        }
        
    }
    
    
    /// Add a card to Inventory
    // Add a MCard instance to the Inventory List, then save
    // Use when find a new card / return cards from hands to inventory
    // Use with below function : RemoveCardToHand()
    public void AddCardToInventory(MCard mCard)
    {
        GameManager.GM.cardsInInventory.Add(mCard);
        GameManager.GM.SaveInventoryCards();
    }
    
    // Remove a card from Inventory
    // Remove the giving MCard in List, then save
    // Use when adding cards to hands
    // Use with below function : AddCardToHand()
    public void RemoveCardFromInventory(MCard mCard)
    {
        GameManager.GM.cardsInInventory.Remove(mCard);
        GameManager.GM.SaveInventoryCards();
    }
    
    // Add a card to Hand
    // Add the giving MCard to the Hand List, then save
    // Use when merging cards
    // Use with up function : RemoveCardFromInventory()
    public void AddCardToHand(MCard mCard)
    {
        GameManager.GM.cardsInHand.Add(mCard);
        GameManager.GM.SaveHandCards();
    }

    // Remove a card from
    // Remove the giving MCard in List, then save
    // Use when find a new card
    // Use with below function : AddCardToHand()
    public void RemoveCardFromHand(MCard mCard)
    {
        GameManager.GM.cardsInHand.Remove(mCard);
        GameManager.GM.SaveHandCards();
    }

    
    
   
    
    
    
}
