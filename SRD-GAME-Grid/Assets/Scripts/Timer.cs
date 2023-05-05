using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{

    public int currentMovementSteps;
    private bool timerLock = false;     // Used to lock the "Load Scene" and make sure Player Death() only called once
    public TMP_Text textMovementSteps;

    
    private void Start()
    {
        timerLock = false;
        currentMovementSteps = GameManager.GM.movementSteps;
        textMovementSteps = GameObject.Find("Text_MovementStep").GetComponent<TMP_Text>();
    }
    
    
    public void CountStep()
    {
        currentMovementSteps--;
    }


    private void Update()
    {
        UpdateBigMapUI();
        
        if (currentMovementSteps <= 0 && !timerLock)
        {
            timerLock = true;
            GameManager.GM.PlayerDeath();
        }
    }
    
    // Show Time On UI
    
    // Convert the float value to minutes+seconds time scale
    // Update the current time in minutes+seconds to Big Map UI
    // USE in UPDATE()

    void UpdateBigMapUI()
    {
        textMovementSteps.text = "Movement Steps:  " + currentMovementSteps + "\n" + 
                                 "Memory Gems:  " + GameManager.GM.MemoryGems;
    }
}
