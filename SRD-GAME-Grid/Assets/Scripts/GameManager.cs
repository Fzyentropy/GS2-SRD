using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
/////////////////////////////////////////////     GAME MANAGER VARIABLES    //////////////////////////////////////////////// 

    // GAME STATUS

    public static GameManager GM;
    public static bool isPlayerAtShelter = true;
    public float gridScale = 2.5f;                       // the transformation scale from "Our Grid" to Unity Unit

    
    // PLAYER STATUS
    
    public static bool isPlayerAcceptingInput;           // Can player move using WASD?
    
    public List<MCard> cardsInInventory;
    public List<MCard> cardsInHand;
    
    public int movementSteps;                       // the movement steps for player, int
    public bool isAbleToRestore;                    // if player can restore (Holding the RESTORE card)
    public bool isAbleToSearch;                     // if player can search (Holding the SEARCH card)
        //add more card effect here

    // MIS
    
    // FILE RELEVANCE
    


    
    
    ////////////////////////////////////////     GAME MANAGER VARIABLES    //////////////////////////////////////////////// 

    
    void Awake()
    {
        // Make Game Manager Singleton
        SingletonGameManager();
        
        // Update Player Location Indicator : isPlayerAtShelter
        UpdatePlayerLocationIndicator();

    }

    
    
    void Start()
    {
        LoadInventoryCards();
        LoadHandCards();

    }


    void Update()
    {   
        
        // if(SceneManager.GetActiveScene().name == "Prototype_1") {UpdateUI();}

    }
    
    
    
    
    
    
    ////////////////////////////////////////     GAME MANAGER FUNCTIONS    //////////////////////////////////////////////// 
    
    
    
    // Implementation
    // Making Game Manager Singleton
    // USE everytime loading a new Scene
    // USE at AWAKE()
    
    void SingletonGameManager()
    {
        if (GM == null)
        {
            DontDestroyOnLoad(gameObject);
            GM = this;
            Debug.Log("Made Game Manager Singleton.");
        }
        else
        {
            Destroy(gameObject);
            Debug.Log("New Game Manager Destroyed.");
        }
    }

    
    
    // Implementation
    // Check which scene is player actually in
    
    // Update Player location Indicator to either "Shelter" or "Big Map"
    // USE everytime loading a new Scene
    // USE at AWAKE()
    
    // isPlayerAtShelter
    // true: Shelter
    // false: Big Map

    void UpdatePlayerLocationIndicator()
    {
        // Check current Scene name and set Player Location Indicator
        
        if (SceneManager.GetActiveScene().name == "Shelter_start")
        {
            isPlayerAtShelter = true;
            Debug.Log("Player Location Indicator is set to:   Shelter");
        }
        if (SceneManager.GetActiveScene().name == "GameWorld") // Remember to Reset name if scene changes
        {
            isPlayerAtShelter = false;
            Debug.Log("Player Location Indicator is set to:   Big Map");
        }
    }
    
    
    
    // Player Death
    
    // IMPLEMENTATION:
    // Player dies, Trigger the Death Animation or Effects, then sent back to the Shelter
        // Set the PlayerLocationIndicator to true (Shelter)
        // Then Load the Shelter scene
    public void PlayerDeath()
    {
        Debug.Log("Player was sent back home.");
        
        isPlayerAtShelter = true;
        SceneManager.LoadScene("Shelter_start", LoadSceneMode.Single);
        
    }
    
    
    
    // Load Inventory Card from SAVE / FOLDER FILES, sync it to the Inventory card list
    // The cards that player owns

    public void LoadInventoryCards()
    {
        // TODO Get current card information from SAVE / FOLDER 
        
        
        // Read all card files
        // Instantiate cards according to the number of scriptableObjects
        MCard[] cardObjects = Resources.LoadAll<MCard>("CurrentCards");
        // GameObject cardInstanceHolder;
        foreach (MCard mCard in cardObjects)
        {
            cardsInInventory.Add(mCard);
        }


    }

    public void SaveInventoryCards()
    {
        // TODO Save current Inventory cards info to SAVE / FOLDER
        
    }
    

    
    
    // Load current or previous hand cards
    public void LoadHandCards()
    {
        // TODO Get current hand cards from SAVE / FOLDER
        
    }

    public void SaveHandCards()
    {
        // TODO Save current Hand cards info to SAVE / FOLDER
    }


    // Resolve Card Effect
    // Set according variables
    public void ResolveCardEffect()
    {
        // Clear Variable
        movementSteps = 0;
        isAbleToRestore = false;
        isAbleToSearch = false;
            // add more card effect variable here
        
        // Resolve card effect according to different tag of effect
        foreach (MCard mCard in cardsInHand)
        {
            if (mCard.cardEffect == CardEffect.MOVEMENT)
            {
                movementSteps += mCard.movementStepAmount;
            }
            if (mCard.cardEffect == CardEffect.RESTORE)
            {
                isAbleToRestore = true;
            }
            if (mCard.cardEffect == CardEffect.SEARCH)
            {
                isAbleToSearch = true;
            }
                // add more card effect resolve here
        }
        
    }










}
