using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CardDisplay : MonoBehaviour
{

    public GameObject card;
    public GameObject cardGrid;
    
    MCard[] cardObjects;

    
    void Start()
    {
        InstantiateCards();
    }


    void Update()
    {
        
    }


    void InstantiateCards()
    {
        
        // Read all card files
        // Instantiate cards according to the number of scriptableObjects
        
        cardObjects = Resources.LoadAll<MCard>("");
        GameObject cardInstanceHolder;
        for (int i = 0; i < cardObjects.Length; i++)
        {
            cardInstanceHolder = Instantiate(card, cardGrid.transform);
            cardInstanceHolder.GetComponentInChildren<CardInstantiateFromScriptableObject>().MCard = cardObjects[i];
        }
            
        

    }
    
    
    
    
}
