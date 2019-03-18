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
        if (Input.GetButtonDown("ShootBubble"))
        {
            Debug.Log("SHOOT");

            
            GameObject bullet = objectPooler.SpawnFromPool("Bubble", firePoint.position, transform.rotation);
        }
    }

   
}
