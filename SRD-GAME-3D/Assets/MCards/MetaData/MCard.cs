using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UIElements.Image;


[CreateAssetMenu(fileName = "A New Card", menuName = "Card")]
public class MCard : ScriptableObject
{

    public string cardName;
    public Sprite cardAvatar;
    [TextArea] public string cardLog;
    [TextArea] public string cardEffect;
    public string cardEffectDescription;
    public float moveTime;
    
    

}
