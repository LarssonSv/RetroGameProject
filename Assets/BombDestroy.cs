using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDestroy : MonoBehaviour
{
    public int health = 10;
    
    public GameObject deathEffect;

    public void TakeDamage (int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            transform.position = new Vector3(0, 6, 0);
            //Destroy();
        }
    }

    //void Destroy()
    //{
        //Instantiate(deathEffect, transform.position, Quaternion.identity);
        //Destroy(gameObject);
    //}


}
