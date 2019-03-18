﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSpawn : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;
    ObjectPooler objectPooler;

    public float fireRate = 2.0f;
    private float nextFire = 0.0f;


    private void Start()
    {
        objectPooler = ObjectPooler.Instance;
    }

    void Update()
    {
        if (Input.GetButtonDown("ShootBubble"))
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
