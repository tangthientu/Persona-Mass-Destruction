using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScene : MonoBehaviour
{
   
    public void ReturnToMainMenuScene()
    {
        SceneManager.LoadScene("Main Menu");

    }
}
