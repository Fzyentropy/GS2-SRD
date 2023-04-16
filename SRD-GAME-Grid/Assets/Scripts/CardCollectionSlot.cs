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
        
        MCardComponent = dropped.GetComponentInChildren<CardInstantiateFromScriptableObject>().MCard;

        if (MCardComponent.cardEffect == "MOVEMENT")
        {
            GameManager.moveTimeInInt -= (int)MCardComponent.moveTime;
            Debug.Log(GameManager.moveTimeInInt);
        }
    }
    
    
}

