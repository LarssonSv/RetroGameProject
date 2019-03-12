#pragma warning disable 0649  //Disabled Warning for unity-editor bug
using UnityEngine;
//Author Simon

public class GameMode : MonoBehaviour
{
    //Publics
    [HideInInspector] public GameObject currentFishPlayer;
    [HideInInspector] public GameObject currentBoatPlayer;

    //Privates
    [SerializeField] [Tooltip("Optional")] GameObject PlayerFishPrefab;
    [SerializeField] [Tooltip("Optional")] GameObject PlayerBoatPrefab;
    [SerializeField] Transform PlayerFishStart;
    [SerializeField] Transform PlayerBoatStart;
    [SerializeField] private GameObject gameOverUI;

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
<<<<<<< HEAD

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
       
 

=======
>>>>>>> 9ffd9f201235b4f54d8e8662b7a09255dbd3bb93
}
