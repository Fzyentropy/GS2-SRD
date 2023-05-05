using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button_Destroythis : MonoBehaviour
{

    public Button button;
    
    void Start()
    {
        if (button == null)
        {
            button = gameObject.GetComponent<Button>();
        }
        
        button.onClick.AddListener(()=> DestroyGameObject());
        
    }

    void DestroyGameObject()
    {
        Destroy(gameObject.transform.parent.gameObject);
    }
    
    
    
}
