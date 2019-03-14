using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawn : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;
   
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
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        
    }
}
