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
    [SerializeField][Tooltip("Optional")] GameObject CameraPrefab;
    [SerializeField] Transform PlayerFishStart;
    [SerializeField] Transform PlayerBoatStart;
    [SerializeField] private GameObject gameOverUI;

    public void StartUp()
    {
        SpawnPlayers();
        SpawnCamera();
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

    public GameObject SpawnCamera()
    {
        if (CameraPrefab)
        {
            currentCamera = Instantiate(CameraPrefab, new Vector3(0, 0, -10), new Quaternion(0, 0, 0, 0));
            return currentCamera;
        }
        
        return currentCamera;
    }

    public void EndGame()
    {
        Debug.Log("GAME OVER");
        gameOverUI.SetActive(true);
    }
       
 

}
