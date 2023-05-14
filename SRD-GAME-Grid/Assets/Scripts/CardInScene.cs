using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class CardInScene : MonoBehaviour
{
    public GameObject cardPrefab;
    private GameObject cardPrefabHolder;
    public MCard mCard;
    private SpriteRenderer spriteRenderer;
    private bool isPlayerCollided = false;
    private bool isCardCollected = false;
    public GameObject collectButton;
    public GameObject collectButtonHolder;
    
    public GameObject blackTransparent;
    private GameObject blackTransparentHolder;
    public Color transparentBlackColor = new Color(0f,0f,0f,0.8f);
    
    
    void Start()
    {
        // InitializeButton();
        checkCardValidate();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        ShowOrHideSprite();
        // SetBlackTransparent();
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
            collectButtonHolder.GetComponent<Button>().onClick.AddListener(() => CollectCard());

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
        }
    }


    void ShowOrHideSprite()
    {
        
        if (GameManager.GM.isAbleToSearch)   // If player holds the SEARCH card
        {
            spriteRenderer.color = Color.white;
        }
        else
        {
            spriteRenderer.color = Color.clear;
        }
        
    }


    public void CollectCard()
    {
        
        isCardCollected = true;
            
        // Card Pick up Implementation
            
            // Show up in UI / Animation
            // collectButton.SetActive(true);
            Destroy(collectButtonHolder);
            
            // blackTransparent.SetActive(true);
            blackTransparentHolder = Instantiate(blackTransparent, GameObject.Find("Canvas_4_black").transform);
            blackTransparentHolder.GetComponent<Image>().color = Color.clear;
            blackTransparentHolder.GetComponent<Image>().DOColor(transparentBlackColor, 0.5f);
            
            cardPrefabHolder = Instantiate(cardPrefab, GameObject.Find("Canvas_4_black").transform);
            cardPrefabHolder.GetComponentInChildren<CardInstance>().mCard = mCard;
            cardPrefabHolder.transform.DOScale(2*cardPrefabHolder.transform.localScale, 1f);
            StartCoroutine(MouseClickToClose());
            
        // Add Card to Card list
        GameManager.GM.cardsInInventory.Add(mCard);

        // Destroy This gameObject
        // Destroy(gameObject);

    }
    
    
    void InitializeButton()
    {
        // Initialize Button References
        if (collectButton == null)
        {
            /*collectButton = GameObject.Find("Button_Collect_Card");
            if (collectButton == null)
            {
                // Instantiate a new button
                Debug.Log("jffffffffffffffffffffffffffffffffffffffffffffffff");
            }*/

            Instantiate(collectButton, GameObject.Find("Canvas_2_UI").transform);
            Debug.Log("fjdksajfldjasflkadjslkfjadskldfj");
        }
        
        // Add Button Click Function
        collectButton.GetComponent<Button>().onClick.AddListener(() => CollectCard());
        
        // Make Button Invisible
        collectButton.SetActive(false);
    }

    void SetBlackTransparent()
    {
        if (blackTransparent == null)
        {
            // blackTransparent = GameObject.Find("Black_Transparent");
            // if (blackTransparent == null)
            // {
            //     // Instantiate a new transparent black screen
            //     
            // }

            Instantiate(blackTransparent, GameObject.Find("Canvas_4_black").transform);
        }
        
        blackTransparent.GetComponent<Image>().color = Color.clear;
        blackTransparent.SetActive(false);
    }
    

    void checkCardValidate()
    {
        if (mCard == null)
        {
            throw new NullReferenceException();
        }
        if (cardPrefab == null)
        {
            throw new NullReferenceException();
        }
    }


    IEnumerator MouseClickToClose()
    {
        bool isClicked = false;
        
        while (!isClicked)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Mouse clicked!");
                isClicked = true;
            }

            yield return null;
        }

        cardPrefabHolder.transform.DOScale(0.2f * cardPrefabHolder.transform.localScale, 0.2f)
            .OnComplete(() =>
            {
                Destroy(cardPrefabHolder);
                blackTransparentHolder.GetComponent<Image>().DOColor(Color.clear, 0.3f)
                    .OnComplete(()=>{Destroy(blackTransparentHolder);});
            });
        
        Destroy(gameObject);
        
    }
    
    
    
    
    
}
