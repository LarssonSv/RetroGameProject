using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
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
        Application.Quit();
    }

    public void Credits ()
    {
        Debug.Log("CREDITS CLICKED");
    }
}
