using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Author: Mattia

public class FishPlayerController : MonoBehaviour
{

    [SerializeField] protected float rotationSpeed = 2f;
    [SerializeField] protected float forceSpeed = 50f;
    //[SerializeField] protected float maxSpeed = 2f;

    protected Rigidbody2D rb2D;
    protected float horizontal = 0f;
    protected float vertical = 0f;
    protected bool bAccelerate = false;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnEnable()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetAxisRaw("VerticalFish") != 0 || (Input.GetAxisRaw("HorizontalFish") != 0))
        {
            vertical = Input.GetAxisRaw("VerticalFish") * Time.deltaTime;
            horizontal = Input.GetAxisRaw("HorizontalFish") * Time.deltaTime;
        }

        float angle = Mathf.Atan2(vertical, horizontal) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(0, 0, angle)), Time.deltaTime * rotationSpeed);

 
        float accelerate = Input.GetAxisRaw("AccelerateFish");

        if (Input.GetButtonDown("AccelerateFish") || accelerate >= 1)
        {
            if(!bAccelerate)
            rb2D.AddRelativeForce(Vector2.left * -100 * Time.deltaTime);

            bAccelerate = true;
            animator.SetBool("IsSwimming", true);           
        }
        else if (Input.GetButtonUp("AccelerateFish") || accelerate <= 0)
        {
            bAccelerate = false;
            animator.SetBool("IsSwimming", false);
        }
       
        if (bAccelerate)  // && rb2D.velocity.magnitude < maxSpeed
        {
            rb2D.AddRelativeForce(Vector2.left * -forceSpeed * Time.deltaTime);
        }
    }

    public void ResetVelocity()
    {
       
        if (rb2D.velocity.magnitude > 1f)
        {
            rb2D.velocity = new Vector2(0f, 0f);

        }

        if (bAccelerate)
        {
            rb2D.AddRelativeForce(Vector2.left * -500 * Time.deltaTime);
        }
    }
}
