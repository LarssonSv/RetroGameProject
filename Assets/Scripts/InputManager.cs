using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager: MonoBehaviour
{

    public GameObject PauseUI;
  

  
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space key was pressed");
            PauseUI.SetActive(true);
            Pause();

        }

    }

     void Pause()
    {
     
            Time.timeScale = 0;
                    
    }

}
