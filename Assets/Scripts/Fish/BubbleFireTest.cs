using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleFireTest : MonoBehaviour
{

    public GameObject bubble;
    public Transform spawner;
    public float speed = 10.0f;


    public float MoveSpeed;
    public float bubbleRate;
    public float bubbleSpeed;

    private Rigidbody2D rb2D;
    private float nextBubble;

    private void Update()
    {

        if (Input.GetButton("Fire1") && Time.time > nextBubble)
        {
            nextBubble = Time.time + bubbleRate;
            GameObject clone = Instantiate (bubble, spawner.position, spawner.rotation)  as GameObject;
            Rigidbody2D bubble_rb = clone.GetComponent<Rigidbody2D>();
            bubble_rb.AddForce(spawner.up * speed);
            //Destroy(clone.gameObject, 1f);
        }
    }
}
