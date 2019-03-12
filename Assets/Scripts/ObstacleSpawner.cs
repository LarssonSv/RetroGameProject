using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Author: Simon
public class ObstacleSpawner : MonoBehaviour
{
    //Publics
    [Header("Spawn Behavior")]
    [Range(0.0f, 100.0f)][Tooltip("Chance of to actually spawn, will properly be moved to be handle by the prefab spawned")] public float spawnChance = 5.0f;
    [Range(0.0f, 15.0f)][Tooltip("Delay before spawn start")]public float delay = 5.0f;
    [Range(0.0f, 10.0f)][Tooltip("Delay before spawn start")]public float repeatRate = 5.0f;

    //Privates
    [Header("Setup")]
    [SerializeField] List<GameObject> obstacles = new List<GameObject>();
    [SerializeField] RailDriver railDriver;

    [Header("Spawn Position Offset from center of screen")]
    [Range(0.0f, 50.0f)] [Tooltip("Spawn offset on X-axis")] public float offsetX = 5.0f;
    [Range(0.0f, 50.0f)] [Tooltip("Spawn offset on Y-axis")] public float offsetY = 5.0f;


    private void Start()
    {
        if(obstacles.Count > 0)
        {
            InvokeRepeating("AttemptSpawn", delay, repeatRate);
        }

    }

    bool AttemptSpawn()
    {
        if(Random.Range(0.0f, 100.0f) < spawnChance)
        {
            Instantiate(obstacles[Random.Range(-1, obstacles.Count + 1)], railDriver.CurrentRailPos, new Quaternion(0f, 0f, 0f, 0f));
            return true;
        }

        return false;
    }





}
