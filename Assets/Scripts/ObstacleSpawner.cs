using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
//Author: Simon
public class ObstacleSpawner : MonoBehaviour
{
    [Header("Spawn Behavior")]
    [Range(0.0f, 100.0f)] [Tooltip("Chance of to actually spawn")] public float spawnChance = 5.0f;
    [Range(0.0f, 15.0f)] [Tooltip("Delay before spawn start")] public float delay = 5.0f;
    [Range(0.0f, 10.0f)] [Tooltip("RepeatRate")] public float repeatRate = 5.0f;

    [Header("Setup")]
    ObjectPooler objectPooler;
    GameObject currentCamera;

    [Header("Spawn Position Offset from center of screen")]
    [Range(0.0f, 50.0f)] [Tooltip("Spawn offset on X-axis")] public int offsetX = 5;
    [Range(0.0f, 50.0f)] [Tooltip("Spawn offset on Y-axis")] public int offsetY = 5;

    Vector3Int spawnPos;




    private void Start()
    {
        currentCamera = GameManager.GM.CurrentGameMode.currentCamera;
        objectPooler = ObjectPooler.Instance;
        InvokeRepeating("AttemptSpawn", delay, repeatRate);
    }

    void AttemptSpawn()
    {
        if(Random.Range(0,100) < spawnChance)
        {
            objectPooler.SpawnFromPool("mine", (currentCamera.transform.position + new Vector3(offsetX + Random.Range(-2,2), Random.Range(-2, 2))), Quaternion.identity);
            objectPooler.SpawnFromPool("shark", (currentCamera.transform.position + new Vector3(offsetX, offsetY, 0)), Quaternion.identity);
        }
    }


}
