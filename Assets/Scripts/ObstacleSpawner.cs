using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
//Author: Simon
public class ObstacleSpawner : MonoBehaviour
{
    [Header("Spawn Behavior")]
    [Range(0.0f, 100.0f)][Tooltip("Chance of to actually spawn, will properly be moved to be handle by the prefab spawned")] public float spawnChance = 5.0f;
    [Range(0.0f, 15.0f)][Tooltip("Delay before spawn start")]public float delay = 5.0f;
    [Range(0.0f, 10.0f)][Tooltip("Delay before spawn start")]public float repeatRate = 5.0f;

    [Header("Setup")]
    [SerializeField] List<GameObject> obstacles = new List<GameObject>();
    [SerializeField] Tilemap map;
    [SerializeField] TileBase temp; //TODO: Will be moved to list later
    GameObject currentCamera;

    [Header("Spawn Position Offset from center of screen")]
    [Range(0.0f, 50.0f)] [Tooltip("Spawn offset on X-axis")] public int offsetX = 5;


    private void Start()
    {
        currentCamera = GameManager.GM.CurrentGameMode.currentCamera;
        if(temp)
        {
            InvokeRepeating("AttemptSpawn", delay, repeatRate);
        }

    }

    bool AttemptSpawn()
    {
        if(Random.Range(0.0f, 100.0f) < spawnChance)
        {
            Vector3Int spawnPos = Vector3Int.FloorToInt((currentCamera.transform.position + new Vector3(offsetX, 0, 0)));
            int i = 0;

            while(i < 10)
            {
                if(!GetCell(map,map.GetCellCenterWorld(spawnPos)))
                {
                    spawnPos.y -= 1;
                    i++;
                }
                else
                {
                    spawnPos.y += 1;
                    map.SetTile(spawnPos, temp);
                    return true;
                }

            }
        }

        return false;
    }
    
    private TileBase GetCell(Tilemap tilemap, Vector3 cellWorldPos)
    {
        return tilemap.GetTile(tilemap.WorldToCell(cellWorldPos));
    }


}
