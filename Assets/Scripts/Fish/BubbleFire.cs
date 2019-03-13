using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleFire : MonoBehaviour
{

    [SerializeField] float speed;

    private Rigidbody2D rb2D;


    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        transform.Translate(Vector3.right * speed * Time.fixedDeltaTime);
    }

    private void Update()
    {
      
    }
}
