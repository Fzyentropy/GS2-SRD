using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardCollectionSlot : MonoBehaviour, IDropHandler
{
    
    private MCard MCardComponent;
    
    
    // Drop the card back to collection
    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        DraggableObject draggableObject = dropped.GetComponent<DraggableObject>();
        draggableObject.parentBeforeDrag = GameObject.Find("CardGrid").transform;
        
        MCardComponent = dropped.GetComponentInChildren<CardInstance>().mCard;

        if (MCardComponent.cardEffect == CardEffect.MOVEMENT)
        {
            GameManager.GM.movementSteps -= MCardComponent.movementStepAmount;
            Debug.Log(GameManager.GM.movementSteps);
        }
    }
    
    
}

