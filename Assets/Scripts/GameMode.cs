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
}
