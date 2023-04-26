using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST_Collision : MonoBehaviour
{

    private bool isPlayerCollided = false;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("shit it collides");
            isPlayerCollided = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("thank god it goes");
            isPlayerCollided = false;
        }
        
    }
    
    private void Update()
    {
        if (isPlayerCollided && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("He triggers my function!");
        }
    }
}
