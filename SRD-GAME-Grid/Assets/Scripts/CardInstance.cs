using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;



/// <summary>
/// Card Instance Script
/// Attach to Card Prefab
/// Initialize the card Interface and Information
/// </summary>
public class CardInstance : MonoBehaviour
{
    // Waiting to be assigned, a MCard ScriptableObject Instance
    public MCard mCard;

    public TMP_Text cardName;
    public Image cardAvatar;
    
    public TMP_Text cardLog;
    public TMP_Text cardEffectDescription;
    
    
    void Start()
    {
        cardName.text = mCard.cardName;
        cardAvatar.sprite = mCard.cardAvatar;
        SetCardlogAccrodingToUpgrade();                  // Set Card Log according to current Upgrade Level
        SetCardEffectDescription();
    }

    
    // Inplementation
    // Set Card Log according to current upgrade level
    // 2 - cardLog2
    // 3 - cardLog3
    // any other - cardLog1
    private void SetCardlogAccrodingToUpgrade()
    {
        if (mCard.currentUpgradeLevel == 2)
        { 
            cardLog.text = mCard.cardLog2;
        }
        else if (mCard.currentUpgradeLevel == 3)
        {
            cardLog.text = mCard.cardLog3;
        }
        else
        {
            cardLog.text = mCard.cardLog1;
        }
    }

    
    // Set Card Effect Description Text according to Card Effect
    // TODO if there's new Card Mechanics, should update this function
    // 
    private void SetCardEffectDescription()
    {
        if (mCard.cardEffect == CardEffect.MOVEMENT)
        {
            cardEffectDescription.text = " MOVEMENT  " + mCard.movementStepAmount;
        }
        if (mCard.cardEffect == CardEffect.RESTORE)
        {
            cardEffectDescription.text = "  RESTORE  ";
        }
        if (mCard.cardEffect == CardEffect.SEARCH)
        {
            cardEffectDescription.text = "  SEARCH  ";
        }




    }
    
    
    

    
}
