using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Author: Mattia

public class EnemyController : MonoBehaviour
{
    [SerializeField] protected float forceSpeed = 15;
    [SerializeField] protected float maxSpeed = 1f;
    [SerializeField] protected float sightDistance = 6f;
    [SerializeField] protected float forceDash = 350;

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

        if (rb2D.velocity.magnitude < maxSpeed)
        {
            if (pointPlayer.magnitude < sightDistance && player.position.x < transform.position.x)
            {
                pointPlayer.Normalize();
                rb2D.AddRelativeForce(pointPlayer * forceDash);
            }
            else
            {
                rb2D.AddRelativeForce(Vector2.left * forceSpeed);
            }
        }
    }
}
