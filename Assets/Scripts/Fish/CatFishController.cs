using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatFishController : MonoBehaviour
{

    
    //publics
   public float MoveSpeed;
    
   

    //privates
    private Rigidbody2D rb2D;
    

    float moveHorizontal;
    float moveVertical;
    Transform firePoint;



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

    

    }







