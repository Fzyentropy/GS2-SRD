using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Button_Exit : MonoBehaviour
{

    public Button button;
    
    void Start()
    {
        if (button == null)
        {
            button = gameObject.GetComponent<Button>();
        }
        button.onClick.AddListener(()=> Exit());
    }

    void Exit()
    {
        SceneManager.LoadScene("GameWorld",LoadSceneMode.Single);
    }
    
}
