using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_Menu : MonoBehaviour
{
    public static bool InPauseMenu = false;
    public GameObject pauseMenuUI;

   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (InPauseMenu)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

    }

    //Function called when pause menu is exited
    public void Resume()
    {
        InPauseMenu = false;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        Debug.Log("Game successfully resumed");
    }
    //Function called when pause menu is entered
    void Pause()
    {
        InPauseMenu = true;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void QuitGame()
    {
        Debug.Log("Game successfully quit");
        Application.Quit();
    }
}
