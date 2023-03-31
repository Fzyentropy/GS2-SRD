using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Exit : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))                              //  When Player enter the Exit, then
        {
            
            // Check Current Cards, and set player status accordingly
            
            
            // Set the player Location Indicator to false (Big Map)
            // Load the big map
            
            GameManager.moveTimeInInt= 11;  Debug.Log("Movetime reset in Exit");
            SceneManager.LoadScene("Prototype_1",LoadSceneMode.Single);
            
            // send a message to Manager, that player has entered the big map, the movement begins
        }
        
    }
    
    
}
