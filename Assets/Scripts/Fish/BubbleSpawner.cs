using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{


    public GameObject bubble;
    public Transform bubbleSpawner;
    public float bubbleRate;
    public float bubbleSpeed;

    private float nextBubble;

    public void FixedUpdate()
    {
        if (Input.GetButton("Fire1") && Time.time > nextBubble)
        {
            nextBubble = Time.time + bubbleRate;
            Instantiate(bubble, bubbleSpawner.position, bubbleSpawner.rotation);



            Shoot();

        }

        void Shoot()
        {
            Debug.Log("SHOOT");
        }


    }
}
