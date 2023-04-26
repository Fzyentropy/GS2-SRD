using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardSlot : MonoBehaviour, IDropHandler
{
    private MCard MCardComponent;
    
    public void OnDrop(PointerEventData eventData)
    {
        GameObject dropped = eventData.pointerDrag;
        DraggableObject draggableObject = dropped.GetComponent<DraggableObject>();
        draggableObject.parentBeforeDrag = transform;

        MCardComponent = dropped.GetComponentInChildren<CardInstance>().mCard;

        if (MCardComponent.cardEffect == CardEffect.MOVEMENT)
        {
            GameManager.movementSteps += MCardComponent.movementStepAmount;
            Debug.Log(GameManager.movementSteps);
        }
    }
    
    
}
