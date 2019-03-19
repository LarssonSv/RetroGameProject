using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSpawn : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;
    ObjectPooler objectPooler;

    public float fireRate = 2.0f;
    private float nextFire = 0.0f;

    public AudioClip bubbleShoot;
    private AudioSource source;

   


    private void Start()
    {
        objectPooler = ObjectPooler.Instance;
        source = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetButtonDown("ShootBubble") && Time.time > nextFire)
        {
            Debug.Log("SHOOT");


            nextFire = Time.time + fireRate;
            GameObject bullet = objectPooler.SpawnFromPool("Bubble", firePoint.position, transform.rotation);
            source.PlayOneShot(bubbleShoot, 1f);

        }
    }

   
}
