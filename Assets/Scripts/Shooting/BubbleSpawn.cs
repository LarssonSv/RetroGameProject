using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSpawn : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;
    ObjectPooler objectPooler;


    private void Start()
    {
        objectPooler = ObjectPooler.Instance;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("SHOOT");
            Shoot();
        }
    }

    void Shoot ()
    {
        GameObject bullet = objectPooler.SpawnFromPool("Bubble", firePoint.position, transform.rotation);
        
    }
}
