using UnityEngine;
//Author: Simon

public class GameManager : MonoBehaviour
{
    //Publics
    [Tooltip("Required!")] public GameMode CurrentGameMode;
    public static GameManager GM;

   
    private void Awake()
    {

        CurrentGameMode = GetComponent<GameMode>();

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
