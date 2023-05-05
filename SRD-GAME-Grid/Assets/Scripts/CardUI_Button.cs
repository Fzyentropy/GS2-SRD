using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardUI_Button : MonoBehaviour
{

    // Card Collection UI Canvas Prefab and its holder
    public GameObject cardCollection;
    public GameObject cardCollectionHolder;

    public Button button;
    
    // Check if player has opened the card UI
    // Use to detect whether the E function is used to open or close the card UI
    public bool isCollectionOpen = false;


    private void Start()
    {
        SetupButton();
    }

    void SetupButton()
    {
        if (button == null)
        {
            button = gameObject.GetComponent<Button>();
        }
        button.onClick.AddListener(()=> OpenCardUI());
    }

    void OpenCardUI()
    {
        cardCollectionHolder = Instantiate(cardCollection);                     // Open the Card UI, Use Instantiate
        CardManager.CM.DisplayInventoryCards();
        CardManager.CM.DisplayHandCards();
    }
    
    
    
    
}
