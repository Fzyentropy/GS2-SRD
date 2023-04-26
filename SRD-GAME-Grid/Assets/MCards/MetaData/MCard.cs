using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using Image = UnityEngine.UIElements.Image;



[CreateAssetMenu(fileName = "A New Card", menuName = "Card")]
public class MCard : ScriptableObject
{

    public string cardName;                     // Card Name
    public Sprite cardAvatar;                   // Card Image

    public int currentUpgradeLevel = 1;         // Current Level Indicator
    [TextArea] public string cardLog1;          // 1st Level Card Log
    [TextArea] public string cardLog2;          // 2nd Level Card Log
    [TextArea] public string cardLog3;          // 3rd Level Card Log
    
    // public string cardEffectDescription;        // Card Effect displayed in card as text
    
    public CardEffect cardEffect;               // Enum of card effect
    public bool isUpgradable = false;           // If the Card is upgradable
    public int movementStepAmount = 0;          // MOVEMENT Variable :  Movement Steps
    public bool restorable = false;             // RESTORE Variable  :  if player can Restore
    public bool searchable = false;             // SEARCH Variable   :  if player can search

}


public enum CardEffect
{
    MOVEMENT,
    RESTORE,
    SEARCH,
}



/// <summary>
/// Show a drop down menu that allows you to choose different skills and their according variables in the Inspector
/// </summary>

[CustomEditor(typeof(MCard))]
public class CardEditor : Editor
{
    public override void OnInspectorGUI()
    {
        
        serializedObject.Update();

        EditorGUILayout.PropertyField(serializedObject.FindProperty("cardName"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("cardAvatar"));
        
        EditorGUILayout.PropertyField(serializedObject.FindProperty("cardLog1"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("cardLog2"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("cardLog3"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("isUpgradable"));
        
        // EditorGUILayout.PropertyField(serializedObject.FindProperty("cardEffectDescription"));
        

        // If you select a ScriptableObject in the Editor, transform it into a MCard, and refer it
        MCard mCard = target as MCard;
        
        // Display the skill type dropdown
        mCard.cardEffect = (CardEffect)EditorGUILayout.EnumPopup("Card Effect", mCard.cardEffect);
        
        // Display the skill parameters based on the selected skill type
        switch (mCard.cardEffect)
        {
            case CardEffect.MOVEMENT:
            {
                mCard.movementStepAmount = EditorGUILayout.IntField("Movement Steps", mCard.movementStepAmount);
                break;
            }
            case CardEffect.RESTORE:
            {
                mCard.restorable = true;
                EditorGUILayout.LabelField("Able to Restore.");
                break;
            }
            case CardEffect.SEARCH:
            {
                mCard.searchable = true;
                EditorGUILayout.LabelField("Able to Search");
                break;
            }
        }

        
        if (GUI.changed)
        {
            EditorUtility.SetDirty(target);
        }
        
        serializedObject.ApplyModifiedProperties();
        
        
        
        
        /*serializedObject.Update();
    
        EditorGUILayout.PropertyField(serializedObject.FindProperty("cardName"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("cardAvatar"));
        
        EditorGUILayout.PropertyField(serializedObject.FindProperty("cardLog1"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("cardLog2"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("cardLog3"));
        
        EditorGUILayout.PropertyField(serializedObject.FindProperty("cardEffectDescription"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("isUpgradable"));

        
        // 添加技能相关的下拉菜单
        var skillProperty = serializedObject.FindProperty("cardEffect");
        skillProperty.enumValueIndex = EditorGUILayout.Popup("Card Effect", skillProperty.enumValueIndex, skillProperty.enumDisplayNames);

        // 根据所选技能类型，显示对应的技能参数
        switch ((CardEffect)skillProperty.enumValueIndex)
        {
            case CardEffect.MOVEMENT:
                EditorGUILayout.PropertyField(serializedObject.FindProperty("movementStepAmount"));
                break;
            case CardEffect.RESTORE:
                EditorGUILayout.PropertyField(serializedObject.FindProperty("restorable"));
                break;
            case CardEffect.SEARCH:
                EditorGUILayout.PropertyField(serializedObject.FindProperty("searchable"));
                break;
        }

        serializedObject.ApplyModifiedProperties();*/


    }
}




/*public void Activate()
        {
            switch (cardEffect)
            {
                case CardEffect.MOVEMENT:
                    Debug.Log("MOVEMENT");
                    break;
                case CardEffect.RESTORE:
                    Debug.Log("RESTORE");
                    break;
                default:
                    Debug.LogError("Invalid skill type.");
                    break;
            }
        }*/