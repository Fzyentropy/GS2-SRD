using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MGemInScene : MonoBehaviour
{


    public int MemeoryGemAmount;
    private SpriteRenderer spriteRenderer;
    private bool isPlayerCollided = false;
    private bool isGemCollected = false;
    public GameObject collectButton;
    private GameObject collectButtonHolder;
    private TMP_Text eventText;

    void Start()
    {
        // InitializeButton();
        GetEventText();
        CheckGemValidate();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        ShowOrHideSprite();
        
    }


    void Update()
    {
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            isPlayerCollided = true;

            // Show Collecting Card UI (Button)
            // collectButton.SetActive(true);
            collectButtonHolder = Instantiate(collectButton, GameObject.Find("Canvas_2_UI").transform);
            collectButtonHolder.GetComponent<Button>().onClick.AddListener(() => CollectGem());
            Debug.Log("Button Instantiated dddddddddddddd");
            
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerCollided = false;

            // Hide Collecting Card UI (Button)
            // collectButton.SetActive(false);

            Destroy(collectButtonHolder);
            Debug.Log("Button destroyed dddddddddddddd");
        }
    }


    void ShowOrHideSprite()
    {

        if (GameManager.GM.isAbleToSearch) // If player holds the SEARCH card
        {
            spriteRenderer.color = Color.white;
        }
        else
        {
            spriteRenderer.color = Color.clear;
        }

    }


    public void CollectGem()
    {

        isGemCollected = true;

        // Gem Pick up Implementation
        
        // Add Gem to GemCount
        GameManager.GM.MemoryGems += MemeoryGemAmount;
        
        // Show up in UI / Animation
        // collectButton.SetActive(false);
        Destroy(collectButtonHolder);
        
        spriteRenderer.DOColor(Color.clear, 1f);
        eventText.text = MemeoryGemAmount + " Memory Gems Collected";
        eventText.DOColor(Color.white, 1.5f);
        eventText.transform.DOMoveY(eventText.transform.position.y + 10, 2f).From();

        StartCoroutine(TextVanish());

        // Destroy This gameObject
        // Destroy(gameObject);

    }


    void InitializeButton()
    {
        // Initialize Button References
        if (collectButton == null)
        {
            // collectButton = GameObject.Find("Button_Collect_MGem");
            // if (collectButton == null)
            // {
            //     // // Instantiate a new button
            //     // GameObject newCollectButton = new GameObject("Button_Collect");
            //     // newCollectButton.transform.parent = GameObject.Find("Canvas_2_UI").transform;
            //     // Button newButton = newCollectButton.AddComponent<Button>();
            //     //
            //     // RectTransform rectTransform = newCollectButton.GetComponent<RectTransform>();
            //     // rectTransform.sizeDelta = new Vector2(392.3f, 92.9f);
            //     
            //
            // }
            
            Instantiate(collectButton, GameObject.Find("Canvas_2_UI").transform);
        }

        // Add Button Click Function
        collectButton.GetComponent<Button>().onClick.AddListener(() => CollectGem());

        // Make Button Invisible
        collectButton.SetActive(false);
    }


    void CheckGemValidate()
    {
        if (MemeoryGemAmount == 0)
        {
            throw new NotImplementedException();
        }
    }


    void GetEventText()
    {
        if (eventText == null)
        {
            eventText = GameObject.Find("Event_Text").GetComponent<TMP_Text>();
            if (eventText == null)
            {
                // Instantiate a new Text
            }
        }

        eventText.text = "";
        eventText.color = Color.clear;
        

    }

    IEnumerator TextVanish()
    {

        yield return new WaitForSeconds(3f);
        eventText.transform.DOMoveY(eventText.transform.position.y + 10, 2f)
            .OnComplete( ()=> {Destroy(gameObject);} );
        

    }

    
    
}


