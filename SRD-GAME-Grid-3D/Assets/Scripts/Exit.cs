using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Exit : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        
        //  When Player enter the Exit, then
        if (other.CompareTag("Player"))                              
        {

            // Set the player Location Indicator to false (Big Map)
            // Load the big map
            
            // GameManager.moveTimeInInt= 11;  Debug.Log("Movetime reset in Exit");
            
            SceneManager.LoadScene("GameWorld",LoadSceneMode.Single);
            
        }
        
    }
    
    
}
