#pragma warning disable 0649  //Disabled Warning for unity-editor bug
using UnityEngine;

public class GameMode : MonoBehaviour
{
    //Publics
    [HideInInspector] public GameObject currentFishPlayer;
    [HideInInspector] public GameObject currentBoatPlayer;
    public GameObject currentCamera;

    //Privates
    [Header("Setup Players")]
    [SerializeField][Tooltip("Optional")] GameObject PlayerFishPrefab;
    [SerializeField] [Tooltip("Optional")] GameObject PlayerBoatPrefab;
    [Header("Setup Players Spawn")]
    [SerializeField] Transform PlayerFishStart;
    [SerializeField] Transform PlayerBoatStart;
    [Header("UI")]
    [SerializeField] GameObject gameOverUI;

    public void StartUp()
    {
        SpawnPlayers();
     
    }

    public void SpawnPlayers()
    {
        if (PlayerFishPrefab)
        {
            currentFishPlayer = Instantiate(PlayerFishPrefab, PlayerFishStart.position, PlayerFishStart.rotation);
        }

        if (PlayerBoatPrefab)
        {
            currentBoatPlayer = Instantiate(PlayerBoatPrefab, PlayerBoatStart.position, PlayerBoatStart.rotation);
        }
    }

    public void EndGame()
    {
        Debug.Log("GAME OVER");
        gameOverUI.SetActive(true);
    }
       
 

}
