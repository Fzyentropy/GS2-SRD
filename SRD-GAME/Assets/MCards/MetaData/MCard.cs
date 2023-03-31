using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "A New Card", menuName = "Card")]
public class MCard : ScriptableObject
{

    public string cardName;
    [TextArea] public string cardDescription;
    [TextArea] public string cardLine;
    [TextArea] public string cardFunction;

    public float moveTime;
    
    public void Function_Movement()
    {
        
    }

    

}
