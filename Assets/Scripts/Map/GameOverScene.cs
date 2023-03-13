using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScene : MonoBehaviour
{
    public Button gameOverButton;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            ReturnToMainMenuScene();
            Debug.Log("Button clicked.");
        }
        
    }
    void ReturnToMainMenuScene()
    {
        SceneManager.LoadScene("Main Menu");

    }
}
