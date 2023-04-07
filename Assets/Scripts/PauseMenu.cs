using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        resumeGame();
        gameIsPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(gameIsPaused==false)
            {
                pauseGame();
            }
            else
                resumeGame();
        }
    }
        

    public void pauseGame()
    {
        
        Time.timeScale = 0f;
        
        pauseMenu.SetActive(true);
        gameIsPaused=true;
        
    }
    public void resumeGame()
    {
        
        Time.timeScale = 1f;
         gameIsPaused=!gameIsPaused;
        pauseMenu.SetActive(false);
        
    }
    public void toggleFullscreen()
    {
        Screen.fullScreen =! Screen.fullScreen;
    }
}
