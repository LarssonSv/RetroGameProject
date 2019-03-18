using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 10;
    public Rigidbody2D rb;
  



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
      
    }

    private void Update()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Bomb bomb = hitInfo.GetComponent<Bomb>();
        if(bomb != null)
        {
            bomb.TakeDamage(damage);
        }


        DestroyObject();
    }

    private void OnCollisionEnter(Collision collision)
    {
        DestroyObject();
    }

    void DestroyObject()
    {
        gameObject.SetActive(false);
    }

}
