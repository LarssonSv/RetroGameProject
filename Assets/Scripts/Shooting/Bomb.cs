﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{

    [SerializeField] float speed = 5.0f;
    [SerializeField] int health = 10;
    [SerializeField] Sprite bubbleSprite;

    SpriteRenderer spriteRender;

    Vector2 endPosition;
    bool hit = false;

    public AudioClip barrelSurface;
    public AudioClip fishHurt;
    public AudioClip BoatHurt;

    private AudioSource source;


    private void Start()
    {
        spriteRender = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            hit = true;
            endPosition = new Vector2(transform.position.x, 3.5f);
            AddBubble();
            source.PlayOneShot(barrelSurface, 1f);
            


        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.transform.CompareTag("BoatPlayer"))
        {
            HealthScript playerHealth = collision.transform.gameObject.GetComponent<HealthScript>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(1);
                source.PlayOneShot(BoatHurt, 1f);
                Debug.Log("hit");
                gameObject.SetActive(false);
            }
        }

        if (collision.gameObject.transform.CompareTag("FishPlayer"))
        {
            HealthScript playerHealth = collision.transform.gameObject.GetComponent<HealthScript>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(1);
                source.PlayOneShot(fishHurt, 1f);
                Debug.Log("hit");
                gameObject.SetActive(false);
            }
        }
    }


    private void Update()
    {
        if (hit)
        {
            transform.position = Vector3.Lerp(transform.position, endPosition, speed * Time.deltaTime);


        }
    }

    void AddBubble()
    {
        spriteRender.sprite = bubbleSprite;
    }


}
