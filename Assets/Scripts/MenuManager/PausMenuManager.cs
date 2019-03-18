using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausMenuManager: MonoBehaviour
{

    public GameObject PauseUI;
  

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("P was pressed");
            PauseUI.SetActive(true);
            Pause();

        }

        if (Input.GetButtonDown("Pause"))
        {
            Debug.Log("Joystick 0 was pressed");
            PauseUI.SetActive(true);
            Pause();
        }
    }

     void Pause()
    {
     
          Time.timeScale = 0;
                    
    }


    public void Resume()
    {
        PauseUI.SetActive(false);
        Time.timeScale = 1;
    }

    public void Restart()

    {
        Debug.Log("Restart Clicked");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;

    }

    public void Quit()
    {
        Debug.Log("App Quit");
        QuitGame();
        
    }

    public void QuitGame()
    {
        Application.Quit();

        UnityEditor.EditorApplication.isPlaying = false;
    }

}
