using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Publics
    [Tooltip("Required!")]
    public GameMode CurrentGameMode;
    public static GameManager GM;

    //Privates
   
    private void Awake()
    {
        if (CurrentGameMode)
        {
            CurrentGameMode.StartUp();
        }
        else
        {
            Debug.Log("CurrentGameMode is null");
        }
        GM = this;


    }


}
