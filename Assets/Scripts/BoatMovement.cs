using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMovement : MonoBehaviour
{
    public float speed = 6f;
    public bool speedModifier = false;
    private Rigidbody2D rb;
    float moveHorizontal;
    float moveVertical;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetAxis("Horizontal") > 0)
        {
            speedModifier = true;
            speed = 2.5f;
        }
        else
        {
            speedModifier = false;
            speed = 6f;
        }
    }

    void FixedUpdate()
    {
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb.AddRelativeForce(movement * speed);
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
    }



}
