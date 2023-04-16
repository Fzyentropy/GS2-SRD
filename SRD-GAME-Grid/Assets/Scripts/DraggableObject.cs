using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableObject : MonoBehaviour, 
    IBeginDragHandler, 
    IDragHandler,
    IEndDragHandler
    // Some Embedded Event in EventSystem
{

    public Transform parentBeforeDrag;
    public Vector3 MouseCompensate;
    public Image image;


    public void OnBeginDrag(PointerEventData eventData)
    {
        
        // Set Mouse Position Compensate to Card [Begin]
        MouseCompensate = transform.position - Input.mousePosition;
        
        // Let the dragging card be on top [Begin]
        parentBeforeDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        
        // let Mouse Check go through the card image [Begin]
        GameObject[] cards = GameObject.FindGameObjectsWithTag("Card");
        for (int i = 0; i < cards.Length; i++)
        {
            cards[i].GetComponent<DraggableObject>().image.raycastTarget = false;
        }
        

    }

    public void OnDrag(PointerEventData eventData)
    { 
        
        // Set Card position to Mouse position
        // Set Mouse position Compensate to card [Drag]
        transform.position = Input.mousePosition + MouseCompensate;
        // transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        
        // Let the dragging card be on top [End]
        transform.SetParent(parentBeforeDrag);
        transform.position = transform.parent.position;
        
        // let Mouse Check go through the card image [End]
        GameObject[] cards = GameObject.FindGameObjectsWithTag("Card");
        for (int i = 0; i < cards.Length; i++)
        {
            cards[i].GetComponent<DraggableObject>().image.raycastTarget = true;
        }
        
    }
}


