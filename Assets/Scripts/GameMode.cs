#pragma warning disable 0649  //Disabled Warning for unity-editor bug
using UnityEngine;

public class GameMode : MonoBehaviour
{
    //Publics
    [HideInInspector] public GameObject currentFishPlayer;
    [HideInInspector] public GameObject currentBoatPlayer;
    [HideInInspector] public GameObject currentCamera;

    //Privates
    [SerializeField][Tooltip("Optional")] GameObject PlayerFishPrefab;
    [SerializeField] [Tooltip("Optional")] GameObject PlayerBoatPrefab;
    [SerializeField] Transform PlayerFishStart;
    [SerializeField] Transform PlayerBoatStart;
    [SerializeField] GameObject gameOverUI;

    public void StartUp()
    {
        SpawnPlayers();
        currentCamera = Camera.main.gameObject;
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
