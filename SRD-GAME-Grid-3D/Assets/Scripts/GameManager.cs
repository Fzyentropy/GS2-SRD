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
    
    public static int moveTimeInInt;                       // the movement time for player in Float, minutes, seconds
    public int moveTimeInMinutes;
    public int moveTimeInSeconds;

    public TMP_Text textTimer;

    
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

        Cursor.visible = false;

    }

    
    
    void Start()
    {
       
       
    }


    void Update()
    {   
        
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
        if (SceneManager.GetActiveScene().name == "GameWorld")
        {
            isPlayerAtShelter = false;
            Debug.Log("Player Location Indicator is set to:   Big Map");
        }
    }



    // Show Time On UI
    
    // Convert the float value to minutes+seconds time scale
    // Update the current time in minutes+seconds to Big Map UI
    // USE in UPDATE()

    void UpdateBigMapUI()
    {
        moveTimeInMinutes = (int)(moveTimeInInt / 60);
        moveTimeInSeconds = (int)(moveTimeInInt % 60);
        
        textTimer = GameObject.Find("Text_Timer").GetComponent<TMP_Text>();
        
        if (moveTimeInMinutes > 0) {textTimer.text = "Timer:  " + moveTimeInMinutes + ":" + moveTimeInSeconds;}
        else {textTimer.text = "Timer:  " + moveTimeInSeconds;}

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
