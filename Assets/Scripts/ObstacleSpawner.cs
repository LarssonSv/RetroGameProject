using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Author: Simon
public class ObstacleSpawner : MonoBehaviour
{
    //Publics
    [Range(0.0f, 100.0f)]public float spawnChance;

    //Privates
    [SerializeField] List<GameObject> obstacles = new List<GameObject>();
    [SerializeField] RailDriver railDriver;

    private void Start()
    {
        
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
