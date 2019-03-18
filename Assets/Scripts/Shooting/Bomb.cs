using System.Collections;
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
            endPosition = new Vector2(transform.position.x, 3.0f);
            AddBubble();

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
                Debug.Log("hit");
                gameObject.SetActive(false);
            }
        }

        if (collision.gameObject.transform.CompareTag("Player"))
        {
            HealthScript playerHealth = collision.transform.gameObject.GetComponent<HealthScript>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(1);
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
