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
        
        if (draggableObject.parentBeforeDrag == GameObject.Find("CardGrid").transform)
        {
            MCardComponent = dropped.GetComponentInChildren<CardInstantiateFromScriptableObject>().MCard;
            
            if (MCardComponent.cardEffect == "MOVEMENT")
            {
                GameManager.moveTimeInInt += (int)MCardComponent.moveTime;
                Debug.Log(GameManager.moveTimeInInt);
            }
        }
        
        draggableObject.parentBeforeDrag = transform;
        
        
    }
    
    
}
