using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishPlayerController : MonoBehaviour
{

    [SerializeField] protected float rotationSpeed = 2f;
    [SerializeField] protected float forceSpeed = 50f;
    [SerializeField] protected float maxSpeed = 2f;

    protected Rigidbody2D rb2D;
    protected float horizontal = 0f;
    protected float vertical = 0f;
    protected bool bAccelerate = false;
    protected bool bMove = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnEnable()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical"))
        {
            bMove = true;
        }
        else if (Input.GetButtonUp("Horizontal") || Input.GetButtonUp("Vertical"))
        {
            bMove = false;
        }



        if (Input.GetAxisRaw("Vertical") != 0 || (Input.GetAxisRaw("Horizontal") != 0))
        {
            vertical = Input.GetAxisRaw("Vertical") * Time.deltaTime;
            horizontal = Input.GetAxisRaw("Horizontal") * Time.deltaTime;
        }

        float angle = Mathf.Atan2(vertical, horizontal) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(0, 0, angle)), Time.deltaTime * rotationSpeed);


        if (Input.GetButtonDown("Jump"))
        {
            bAccelerate = true;
        }
        else if (Input.GetButtonUp("Jump"))
        {
            bAccelerate = false;
        }
       
        if (bAccelerate && rb2D.velocity.magnitude < maxSpeed)
        {
            rb2D.AddRelativeForce(Vector2.left * -forceSpeed * Time.deltaTime);
        }
    }
}
