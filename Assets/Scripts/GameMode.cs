#pragma warning disable 0649  //Disabled Warning for unity-editor bug
using UnityEngine;

public class GameMode : MonoBehaviour
{
    //Publics
    [HideInInspector] public GameObject currentPlayer;
    [HideInInspector] public GameObject currentCamera;
    public Transform playerStart;

    //Privates
    [SerializeField][Tooltip("Optional")] GameObject PlayerPrefab;
    [SerializeField][Tooltip("Optional")] GameObject CameraPrefab;

    public void StartUp()
    {
        SpawnPlayer();
        SpawnCamera();
    }

    public GameObject SpawnPlayer()
    {
        if (PlayerPrefab)
        {
            currentPlayer = Instantiate(PlayerPrefab, playerStart.position, playerStart.rotation);
            return currentPlayer;
        }
        
        return null;
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

}
