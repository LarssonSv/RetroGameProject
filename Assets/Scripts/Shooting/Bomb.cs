using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{

    [SerializeField] float speed = 5.0f;
    [SerializeField] int health = 10;
    [SerializeField] Sprite bubbleSprite;

    [Header("Blast Settings")]
    [SerializeField] [Range(0, 20)] float blastRadius = 4;
    [SerializeField] [Range(0, 20)] float pushback = 5;
    [SerializeField] [Range(0, 20)] int damage = 1;

    float timer = 0;

    bool debugSphere = false;

    SpriteRenderer spriteRender;

    Vector2 endPosition;
    bool hit = false;



    public AudioClip barrelSurface;
    public AudioClip fishHurt;
    public AudioClip BoatHurt;

    public AudioSource source;
    Animator anim;


    private void Start()
    {
        spriteRender = GetComponent<SpriteRenderer>();
        source = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            hit = true;
            endPosition = new Vector2(transform.position.x, 4f);
            source.PlayOneShot(barrelSurface, 1f);
            anim.SetBool("Bubble", true);

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
                DestroyObject();
            }
        }

        if (collision.gameObject.transform.CompareTag("FishPlayer"))
        {
            HealthScript playerHealth = collision.transform.gameObject.GetComponent<HealthScript>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(1);
                source.PlayOneShot(fishHurt, 1f);
                DestroyObject();
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (debugSphere)
        {
            Gizmos.DrawSphere(transform.position, blastRadius);
            debugSphere = false;
        }

    }


    private void Update()
    {
        timer += 0.05f;
        if (hit)
        {
            transform.position = Vector3.Lerp(transform.position, endPosition, speed * Time.deltaTime);
        }

    }

    public void Explode()
    {
        if (timer > 3f)
        {
            debugSphere = true;

            anim.SetBool("explode", true);

            RaycastHit2D[] hit = Physics2D.CircleCastAll(transform.position, blastRadius, Vector2.zero);

            foreach (RaycastHit2D x in hit)
            {
                if (x.transform.CompareTag("FishPlayer"))
                {
                    HealthScript health = x.transform.GetComponent<HealthScript>();
                    Rigidbody2D rb = x.transform.GetComponent<Rigidbody2D>();

                    if (health)
                    {
                        health.TakeDamage(damage);
                    }

                    if (rb)
                    {
                        Vector2 heading = transform.position - x.transform.position;
                        rb.AddForce(-heading * pushback);
                    }

                }
            }

            Invoke("DestroyObject", 1.5f);

            
        }
    }

    public void DestroyObject()
    {
        gameObject.SetActive(false);
        hit = false;
        timer = 0;
    }

}
