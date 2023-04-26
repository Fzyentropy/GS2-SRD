using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardCollection : MonoBehaviour
{

    public GameObject cardCollection;
    public GameObject cardCollectionHolder;
    public GameObject UI_E;
    private GameObject UI_E_Holder;
    public bool canOpenCollection = false;
    public bool isCollectionOpen = false;

    public GameObject player;


    // Check Player Collision
    
    // On Trigger Enter
    // Once Player get into the card collection area
    // the E UI show up
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Instantiate UI_E");
            
            UI_E_Holder = Instantiate(UI_E);
            UI_E_Holder.transform.position = GameObject.Find("UI_E_Position").transform.position;

            canOpenCollection = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        // canOpenCollection = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(UI_E_Holder);
            
            canOpenCollection = false;
            
            Debug.Log("UI_E destroyed");
        }
    }


    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) & canOpenCollection & !isCollectionOpen)
        {
            cardCollectionHolder = Instantiate(cardCollection);
            Cursor.visible = true;
            
            isCollectionOpen = true;
            Debug.Log("card collection instantiated");
        }
        else
        if ((Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Escape)) && isCollectionOpen)
        {
            Destroy(cardCollectionHolder);
            Cursor.visible = false;
            isCollectionOpen = false;
            Debug.Log("card collection destroyed");
        }
    }

    
    
    
    
}
