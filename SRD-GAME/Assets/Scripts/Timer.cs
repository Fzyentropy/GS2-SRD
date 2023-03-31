using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MovementTimer());
    }

    
    
    IEnumerator MovementTimer()
    {
        
        // Check Current cards, add up the movement time from all the cards
        // Convert minutes and seconds to IEnumerator calculation value
        // TODO : Switch to Adding up Card1 + Card2 + Card3
        GameManager.moveTimeInInt = 9;
        Debug.Log("Timer time reseted.");
        
        
        // if it does not reach 0, then keep counting (Timer--)
        // if it reaches 0, call "Player Death" function
        while (true)
        {
            if (GameManager.moveTimeInInt <= 0) { Debug.Log("Timer break"); break; }
            yield return new WaitForSeconds(1);
            GameManager.moveTimeInInt--;
            Debug.Log("Timer is counting  : " + GameManager.moveTimeInInt);
        }
        
        GameManager.GM.PlayerDeath();
        
    }
}
