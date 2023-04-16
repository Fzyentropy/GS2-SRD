using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardInstantiateFromScriptableObject : MonoBehaviour
{

    public MCard MCard;

    public TMP_Text cardName;
    public Image cardAvatar;
    public TMP_Text cardLog;
    public TMP_Text cardEffect;
    public TMP_Text cardEffectDescription;
    
    
    void Start()
    {
        cardName.text = MCard.cardName;
        cardAvatar.sprite = MCard.cardAvatar;
        cardLog.text = MCard.cardLog;
        cardEffect.text = MCard.cardEffect;
        cardEffectDescription.text = MCard.cardEffectDescription;
    }

    
}
