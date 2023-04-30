using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardSlot : MonoBehaviour, IDropHandler
{
    private CardInstance _cardInstance;
    private DraggableObject _draggableObject;
    
    public void OnDrop(PointerEventData eventData)
    {
        // Adjust dragging and layer changes
        GameObject dropped = eventData.pointerDrag;
        _draggableObject = dropped.GetComponent<DraggableObject>();
        _cardInstance = dropped.GetComponentInChildren<CardInstance>();

        // Detect if the card is dropped to the hand Slot, if it does, Resolve drop to Hand
        if (gameObject.CompareTag("Slot_Hand"))
        {
            _draggableObject.parentBeforeDrag = transform;
            DropToHand(_cardInstance);
        }
        
        // Detect if the card is dropped to the Inventory, if it does, Resolve drop to Inventory
        if (gameObject.CompareTag("Slot_Inventory"))
        {
            _draggableObject.parentBeforeDrag = GameObject.Find("CardGrid").transform;
            DropToInventory(_cardInstance);
        }
    }
    
    
    /// Drop from Inventory to Hand
    public void DropToHand(CardInstance cardInstance)
    {
        // Remove the MCard Instance from the Inventory List, and Add it into the Hand list
        GameManager.GM.cardsInInventory.Remove(cardInstance.mCard);
        GameManager.GM.cardsInHand.Add(cardInstance.mCard);
        // Resolve Card Effect
        GameManager.GM.ResolveCardEffect();
    }
    
    
    /// Drop from Hand to Inventory
    public void DropToInventory(CardInstance cardInstance)
    {
        // Remove the MCard Instance from the Hand List, and Add it into the Inventory list
        GameManager.GM.cardsInHand.Remove(cardInstance.mCard);
        GameManager.GM.cardsInInventory.Add(cardInstance.mCard);
        // Remove the MCard instance from the 
        GameManager.GM.ResolveCardEffect();
    }

   
    
    
}
