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


    // PLAYER STATUS

    public static bool isPlayerAcceptingInput;           // Can player move using WASD?
    
    public static int movementSteps;                     // the movement steps for player, int

    public float gridScale = 2.5f;                          // the transformation scale from "Our Grid" to Unity Unit


    // MIS
    
    // FILE RELEVANCE
    
    

    public Image cardImage;

    
    
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
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
}
