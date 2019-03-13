using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatFishController : MonoBehaviour
{
    public float MoveSpeed;
  
    private Rigidbody2D rb2D;
    float moveHorizontal;
    float moveVertical;

    public GameObject bubble;
    public Transform bubbleSpawner;
    public float bubbleRate;
    public float bubbleSpeed;

  
    private float nextBubble;

    public float bubbleForce = 10.0f;


    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }



    void Update()
    {
       
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2D.AddRelativeForce(movement * MoveSpeed);
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");

    }

    public void FixedUpdate()
    {
        if (Input.GetButton("Fire1") && Time.time > nextBubble)
        {
            nextBubble = Time.time + bubbleRate;
            Instantiate(bubble, bubbleSpawner.position, bubbleSpawner.rotation);
           

        }
     
    }






}
