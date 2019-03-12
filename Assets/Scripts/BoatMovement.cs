using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMovement : MonoBehaviour
{
    public float speed = 8f;
    public bool speedModifier = false;
    public bool onWaterSurface;
    private Rigidbody2D rb2D;
    float moveHorizontal;
    float moveVertical;
    public LayerMask waterSurface;
    public Vector2 jumpHeight;


    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void IsFloating()
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        float distance = 0.6f;

        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, waterSurface);

        if (hit.collider != null)
        {
            onWaterSurface = true;
        }
        else
        {
            onWaterSurface = false;
        }
    }

    void Update()
    {
        IsFloating();

        if (Input.GetAxis("Horizontal") > 0)
        {
            speedModifier = true;
            speed = 4f;
        }
        else
        {
            speedModifier = false;
            speed = 8f;
        }

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2D.AddRelativeForce(movement * speed);
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Jump") && onWaterSurface == true)
        {
            GetComponent<Rigidbody2D>().AddRelativeForce(jumpHeight, ForceMode2D.Impulse);
        }
    }






}
