using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatFishController : MonoBehaviour
{

    [SerializeField] float speed;



    //publics
    public GameObject bubble;
    public Transform bubbleSpawner;
    public float MoveSpeed;
    public float bubbleRate;
    public float bubbleSpeed;
    public float bubbleForce = 10.0f;


    //privates
    private Rigidbody2D rb2D;
    private float nextBubble;

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







