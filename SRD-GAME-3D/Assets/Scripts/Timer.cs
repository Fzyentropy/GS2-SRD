using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{

    public int moveTime;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MovementTimer());
    }

    

    // Coroutine
    // Set the Player Movement Timer
    // USE when entering the Big Map
    
    // Initialize Timer 
    // Timer Implementation Loop
    // Call Player Death function after counting down to 0
    
    IEnumerator MovementTimer()
    {
        
        // Check Current cards, add up the movement time from all the cards
        // Convert minutes and seconds to IEnumerator calculation value
        // TODO : Switch to Adding up Card1 + Card2 + Card3
        moveTime = GameManager.moveTimeInInt;
        Debug.Log("Timer time reseted.");
        
        
        
        // if it does not reach 0, then keep counting (Timer--)
        // if it reaches 0, break the counting
        while (true)
        {
            if (moveTime <= 0) { Debug.Log("Timer break"); break; }
            yield return new WaitForSeconds(1);
            moveTime--;
            GameManager.moveTimeInInt = moveTime;
            Debug.Log("Timer is counting  : " + moveTime);
        }
        
        
        // If time out and counting stops, Player dies and go back to the Shelter
        GameManager.GM.PlayerDeath();
        
    }
}
