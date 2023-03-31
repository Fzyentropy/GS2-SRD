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
    
    public float moveTimeInFloat;                       // the movement time for player in Float, minutes, seconds
    public int moveTimeInMinutes;
    public int moveTimeInSeconds;

    public TMP_Text textTimer;

    
    // MIS





    // FILE RELEVANCE
    
    

    public Image cardImage;

    
    
    ////////////////////////////////////////     GAME MANAGER VARIABLES    //////////////////////////////////////////////// 

    
    private void Awake()
    {
        // Make Game Manager Singleton
        SingletonGameManager();
        
        // Update Player Location Indicator : isPlayerAtShelter
        UpdatePlayerLocationIndicator();
        
        // If Player is not in Shelter (Player is in Big Map), then start the timer
        if (!isPlayerAtShelter)
        {
            StartCoroutine(MovementTimer());
            Debug.Log("Timer Started.");
        }
        
    }

    
    
    void Start()
    {
        
       
    }


    void Update()
    {   
        
        // CheckPlayerMovement();
        // if(SceneManager.GetActiveScene().name == "Prototype_1") {UpdateUI();}
        if (!isPlayerAtShelter) {UpdateBigMapUI();}
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
        if (SceneManager.GetActiveScene().name == "Prototype_1")
        {
            isPlayerAtShelter = false;
            Debug.Log("Player Location Indicator is set to:   Big Map");
        }
    }
    
    
    
    
    // Check if the timer of MOVEMENT goes to zero 

    void CheckPlayerMovement()
    {
        
        if (moveTimeInFloat > 0)
        {
            if (!isPlayerAcceptingInput)
            {
                isPlayerAcceptingInput = true;
            }
        }


        if (moveTimeInFloat <= 0)
        {
            // Player dies and go back to the house. 
            PlayerDeath();                                       
            
        }
        
        
    }


    
    // USE when entering the Big Map
    // Coroutine
    // Set the Player Movement Timer
    
    // Initialize Timer 
    // Timer Implementation Loop
    // check the status of timer
    
    IEnumerator MovementTimer()
    {
        
           
        // Check Current cards, add up the movement time from all the cards
        // Convert minutes and seconds to IEnumerator calculation value
        // TODO : Switch to Adding up Card1 + Card2 + Card3
        moveTimeInFloat = 10f;      
        
    
    
        // if it does not reach 0, then keep counting (Timer--)
        // if it reaches 0, call "Player Death" function
        while (true)
        {
            if (moveTimeInFloat <= 0) { break; }
            yield return new WaitForSeconds(1);
            moveTimeInFloat--;
        }
        
        PlayerDeath();
    
        
        yield return null;
    }


    // USE in UPDATE()
    // Show Time On UI
    // Convert the float value to minutes+seconds time scale
    // Update the current time in minutes+seconds to Big Map UI

    void UpdateBigMapUI()
    {
        moveTimeInMinutes = (int)(moveTimeInFloat / 60);
        moveTimeInSeconds = (int)(moveTimeInFloat % 60);
        
        // if textTimer is not assigned, then assign the Text_Timer in UI Canvas to it
        if (!isPlayerAtShelter)
        {
            /*// Debug.Log("it runs here");
            GameObject textGameObject = GameObject.Find("Text_Timer");
            if(textGameObject != null) {Debug.Log("Game Object found");}
            textTimer = textGameObject.GetComponent<TMP_Text>();
            if(textTimer != null) {Debug.Log("Text Component found");}*/
            
            
            
            textTimer = GameObject.Find("Text_Timer").GetComponent<TMP_Text>();
        }
        
        if (moveTimeInMinutes > 0) {textTimer.text = "Timer:  " + moveTimeInMinutes + ":" + moveTimeInSeconds;}
        else {textTimer.text = "Timer:  " + moveTimeInSeconds;}

    }
    
    
    // Player Death
    // IMPLEMENTATION:
    // Player dies, Trigger the Death Animation or Effects, then sent back to the Shelter
        // Set the PlayerLocationIndicator to true (Shelter)
        // Then Load the Shelter scene
    void PlayerDeath()
    {
        Debug.Log("Player was sent back home.");
        
        isPlayerAtShelter = true;
        SceneManager.LoadScene("Shelter_start", LoadSceneMode.Single);
    }
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
}
