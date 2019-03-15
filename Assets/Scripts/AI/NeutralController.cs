using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeutralController : MonoBehaviour
{
    [SerializeField] protected float forceSpeed = 80;
    [SerializeField] protected float maxSpeed = 1f;


    protected Transform player;
    protected Rigidbody2D rb2D;
    protected bool bChange = false;

    private void OnEnable()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        GameManager currentGM = GameManager.GM;

        if (currentGM)
        {
            GameMode gameMode = currentGM.CurrentGameMode;
            if (gameMode)
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

        if (rb2D.velocity.magnitude < maxSpeed)
        {
            Vector3 direction = Vector3.left + player.position;
            float isBehindPlayer = Vector3.Dot(transform.position, direction);

            Debug.DrawLine(player.position, direction * 2, Color.green);
            print(isBehindPlayer);


            //if(isBehindPlayer > 0)
            //{
            //    print("it's behind");
            //}
            //else
            //{
            //    print("it's not");
            //}

            if (bChange)
            {
                rb2D.AddRelativeForce(pointPlayer * forceSpeed); // * Time.deltaTime
                bChange = false;
            }
            else
            {
                rb2D.AddRelativeForce(Vector2.left * forceSpeed); // * Time.deltaTime
                bChange = true;
            }
        }
    }
}
