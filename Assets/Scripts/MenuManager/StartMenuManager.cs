using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuManager : MonoBehaviour
{

    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

  

    public void Controls()
    {
        Debug.Log("CONTROLS CLICKED");
    }


    public void QuitGame()
    {
        Debug.Log("QUIT CLICKED");
        Quit();
    }

    public void Credits ()
    {
        Debug.Log("CREDITS CLICKED");
    }

    public void Quit()
    {
        Application.Quit();

        //UnityEditor.EditorApplication.isPlaying = false;

    }
}
