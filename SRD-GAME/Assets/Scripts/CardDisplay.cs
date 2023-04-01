using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDisplay : MonoBehaviour
{

    public GameObject card;
    public GameObject cardGridHolder;
    
    
    void Start()
    {
        InstantiateCards();
    }


    void Update()
    {
        
    }


    void InstantiateCards()
    {
        cardGridHolder = Instantiate(card, gameObject.transform);
        // cardGridHolder.transform.position = new Vector2(0, 0);

    }
    
    
    
    
}
