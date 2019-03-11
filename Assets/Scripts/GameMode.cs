#pragma warning disable 0649  //Disabled Warning for unity-editor bug
using UnityEngine;

public class GameMode : MonoBehaviour
{
    //Publics
    [HideInInspector] public GameObject currentPlayer;
    [HideInInspector] public GameObject currentCamera;
    public Transform playerStart;

    //Privates
    [SerializeField] GameObject PlayerPrefab;
    [SerializeField] GameObject CameraPrefab;

    public void StartUp()
    {
        SpawnPlayer();
        SpawnCamera();
    }

    public GameObject SpawnPlayer()
    {
        currentPlayer = Instantiate(PlayerPrefab, playerStart.position, playerStart.rotation);
        return currentPlayer;
    }

    public GameObject SpawnCamera()
    {
        currentCamera = Instantiate(CameraPrefab, new Vector3(0,0,-10), new Quaternion(0, 0, 0, 0));
        return currentCamera;
    }

}
