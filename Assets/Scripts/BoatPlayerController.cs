using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatPlayerController : MonoBehaviour
{
    public float speed = 16f;
    public bool speedModifier = false;
    public bool onWaterSurface;
    private Rigidbody2D rb2D;
    float moveHorizontal;
    float moveVertical;
    public LayerMask waterSurface;
    public Vector2 jumpHeight;
    public float fallmultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    public AudioClip BarrelDropSound;
    private AudioSource source;

    private Quaternion bombPosition;
    public float bombRate;
    private float nextBomb;

    ObjectPooler objectPooler;


    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        objectPooler = ObjectPooler.Instance;
        source = GetComponent<AudioSource>();
        
    }

    void IsFloating()
    {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        float distance = 1f;

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

        if (Input.GetAxis("HorizontalBoat") > 0)
        {
            speedModifier = true;
            speed = 13f;
        }
        else
        {
            speedModifier = false;
            speed = 16f;
        }

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2D.AddRelativeForce(movement * speed);
        moveHorizontal = Input.GetAxis("HorizontalBoat");
        moveVertical = Input.GetAxis("VerticalBoat");

        if (Input.GetButtonDown("BoatJump") && onWaterSurface == true)
        {

            rb2D.AddRelativeForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);

        }

        if (Input.GetButton("BoatBombDrop") && onWaterSurface && Time.time > nextBomb)
        {
            nextBomb = Time.time + bombRate;
            objectPooler.SpawnFromPool("Bomb", new Vector3(transform.position.x, transform.position.y - 3, 0), bombPosition);
            source.PlayOneShot(BarrelDropSound, 1f);
            Debug.Log("Bomb");
        }

        BetterJump();

    }


    void BetterJump()
    {
        if (rb2D.velocity.y < 1)
        {
            rb2D.velocity += Vector2.up * Physics2D.gravity.y * (fallmultiplier - 1) * Time.deltaTime;
        }

        else if (rb2D.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb2D.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }




}
