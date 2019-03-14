using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
//Author: Simon
public class ObstacleSpawner : MonoBehaviour
{
    [Header("Spawn Behavior")]
    [Range(0.0f, 100.0f)] [Tooltip("Chance of to actually spawn, will properly be moved to be handle by the prefab spawned")] public float spawnChance = 5.0f;
    [Range(0.0f, 15.0f)] [Tooltip("Delay before spawn start")] public float delay = 5.0f;
    [Range(0.0f, 10.0f)] [Tooltip("Delay before spawn start")] public float repeatRate = 5.0f;

    [Header("Setup")]
    [SerializeField] List<GameObject> obstacles = new List<GameObject>();
    [SerializeField] Tilemap map;
    [SerializeField] TileBase temp; //TODO: Will be moved to list later
    GameObject currentCamera;

    [Header("Spawn Position Offset from center of screen")]
    [Range(0.0f, 50.0f)] [Tooltip("Spawn offset on X-axis")] public int offsetX = 5;
    [Range(0.0f, 50.0f)] [Tooltip("Spawn offset on Y-axis")] public int offsetY = 5;

    Vector3Int spawnPos;

    private void Start()
    {
        currentCamera = GameManager.GM.CurrentGameMode.currentCamera;
        if (temp)
        {
            InvokeRepeating("AttemptSpawn", delay, repeatRate);
        }

    }

    void AttemptSpawn()
    {
        if (AttemptSpawnUnderWater())
        {

        }

        if (AttemptSpawnOnSurface())
        {

        }

    }

    bool AttemptSpawnUnderWater()
    {
        if (Random.Range(0.0f, 100.0f) < spawnChance)
        {
            spawnPos = Vector3Int.RoundToInt((currentCamera.transform.position + new Vector3(offsetX, 0, 0)));
            int i = 0;

            while (i < 10)
            {
                if (!GetCell(map, map.GetCellCenterWorld(spawnPos)))
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

    bool AttemptSpawnOnSurface()
    {
        if (Random.Range(0.0f, 100.0f) < spawnChance)
        {
            spawnPos = Vector3Int.RoundToInt((new Vector3(currentCamera.transform.position.x + offsetX, offsetY, 0)));
            map.SetTile(spawnPos, temp);
            return true;

        }
        return false;
    }



    private TileBase GetCell(Tilemap tilemap, Vector3 cellWorldPos)
    {
        return tilemap.GetTile(tilemap.WorldToCell(cellWorldPos));
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(spawnPos, new Vector3(0.3f, 0.3f, 0.3f));
    }

}
