using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Restorable : MonoBehaviour
{
    public GameObject restoreButton;
    public SpriteRenderer buildingSprite;           // sprite of the building
    public bool isRestored = false;                  // if the building has been restored
    public bool isButtonShown = false;              // if the Button is shown, true: showed, false; hidden
    
    void Start()
    {
        
        // Initialize Button References
        if (restoreButton == null)
        {
            restoreButton = GameObject.Find("Button_Restore");
            if (restoreButton == null)
            {
                // Instantiate a new button
            }
        }
        
        restoreButton.GetComponent<Button>().onClick.AddListener(() => RestoreButtonClick());   // Set button function
        restoreButton.SetActive(false);                                                             // Deactivate Button
        
        buildingSprite = gameObject.GetComponent<SpriteRenderer>();
        buildingSprite.color = Color.clear;
        
    }


    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // if the building is restored, show nothing
            if (!isRestored)  // when the building is not restored
            {
                ShowRestoreButton();
                isButtonShown = true;
                Debug.Log("isButtonshown is : " + isButtonShown);
            }
            
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (isButtonShown)
            {
                HideRestoreButton();
                isButtonShown = false;
                Debug.Log("isButtonshown is : " + isButtonShown);
            }

        }
    }

    
    // Generate Restore UI according to player restore status
    // if didn't bring restore card then show a grew button
    void ShowRestoreButton()
    {
        
        if (GameManager.GM.isAbleToRestore)       // if player has Restore card
        {
            // SHOW Restore Button
            restoreButton.GetComponent<Button>().interactable = true;
            Debug.Log("Button shown, and player has the RESTORE");
        }
        else                                      // if player don't have Restore card
        {
            // SHOW grey Restore Button
            restoreButton.GetComponent<Button>().interactable = false;
            Debug.Log("Button shown, but player don't have the RESTORE");
        }
        
        restoreButton.SetActive(true);
    }
    void HideRestoreButton()
    {
        restoreButton.SetActive(false);
    }


    void RestoreButtonClick()
    {
        // Button Vanish
        restoreButton.SetActive(false);
        isRestored = true;
        
        // sprite.color
        buildingSprite.DOColor(Color.white, 1.5f);
    }
    
    
    
}
