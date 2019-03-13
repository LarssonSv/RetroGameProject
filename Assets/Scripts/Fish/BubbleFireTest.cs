using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleFireTest : MonoBehaviour
{

    public GameObject bubble;
    public Transform spawner;
    public float speed = 100.0f;


    private void Update()
    {

        if (Input.GetButton("Fire1"))
        {
            GameObject clone = Instantiate (bubble, spawner.position, spawner.rotation)  as GameObject;
            Rigidbody2D bubble_rb = clone.GetComponent<Rigidbody2D>();
            bubble_rb.AddForce(spawner.forward * speed);
        }
    }
}
