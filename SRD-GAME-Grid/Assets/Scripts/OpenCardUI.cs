using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCardUI : MonoBehaviour
{

    // Card Collection UI Canvas Prefab and its holder
    public GameObject cardCollection;
    public GameObject cardCollectionHolder;
    
    // The pop-up E UI and its holder
    public GameObject UI_E;
    private GameObject UI_E_Holder;
    
    // Check if player is able to open the card UI
    // Set to true when player is near the "Fire" and "E"
    public bool canOpenCollection = false;
    
    // Check if player has opened the card UI
    // Use to detect whether the E function is used to open or close the card UI
    public bool isCollectionOpen = false;
    
    
    
    // Check Player Collision
    
    // On Trigger Enter
    // Once Player get into the card collection area
    // the E UI show up
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Debug.Log("Instantiate UI_E");
            UI_E_Holder = Instantiate(UI_E, GameObject.Find("Fire").transform);
            canOpenCollection = true;
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        // canOpenCollection = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(UI_E_Holder);
            canOpenCollection = false;
            // Debug.Log("UI_E destroyed");
        }
    }


    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) & canOpenCollection & !isCollectionOpen)
        {
            cardCollectionHolder = Instantiate(cardCollection);                     // Open the Card UI, Use Instantiate
            isCollectionOpen = true;
            Debug.Log("card collection instantiated");
        }
        else
        if ((Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Escape)) && isCollectionOpen)
        {
            Destroy(cardCollectionHolder);                                          // Destroy Card UI
            isCollectionOpen = false;
            Debug.Log("card collection destroyed");
        }
    }

    
    
    
    
}
