using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    public Image cardImage;

    
    void Start()
    {
        
    }


    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            Debug.Log("Mouse Scroll UP");
        }
        
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            Debug.Log("Mouse Scroll DOWN");
        }
    }
}
