using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMovement : MonoBehaviour
{
    public BoxCollider2D playerCollider;
    public float moveSpeed = 5f;

    void Start()
    {
        playerCollider = this.GetComponent<BoxCollider2D>(); 
    }


    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, 0f);

        transform.Translate(movement * Time.deltaTime * moveSpeed);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {

        }
    }

}
