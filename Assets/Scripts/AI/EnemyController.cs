using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Author: Mattia

public class EnemyController : MonoBehaviour
{
    [SerializeField] protected float forceSpeed = 80;
    [SerializeField] protected float maxSpeed = 1f;


    protected Transform player;
    protected Rigidbody2D rb2D;

    private void OnEnable()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        GameManager currentGM = GameManager.GM;

        if(currentGM)
        {
            GameMode gameMode = currentGM.CurrentGameMode;
            if(gameMode)
            {
                player = gameMode.currentFishPlayer.transform;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 distance3d = player.position - transform.position;
        Vector2 pointPlayer = new Vector2(distance3d.x, distance3d.y);
        pointPlayer.Normalize();

        if(rb2D.velocity.magnitude < maxSpeed)
        {
            rb2D.AddRelativeForce(pointPlayer * forceSpeed); // * Time.deltaTime
        }
    }
}
