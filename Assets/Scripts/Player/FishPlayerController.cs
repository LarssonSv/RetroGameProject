using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishPlayerController : MonoBehaviour
{

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



        //if (bMove)
        //{
            horizontal = Input.GetAxis("Vertical") * Time.deltaTime;
            vertical = Input.GetAxis("Horizontal") * Time.deltaTime;
            //vertical = -vertical;
        //}


        // OR INSIDE IF????
        float angle = Mathf.Atan2(horizontal, vertical) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(new Vector3(0, 0, angle)), Time.deltaTime * 2);


        if (Input.GetButtonDown("Jump"))
        {
            bAccelerate = true;
        }
        else if (Input.GetButtonUp("Jump"))
        {
            bAccelerate = false;
        }

        if (bAccelerate)
        {
            rb2D.AddRelativeForce(Vector2.left * -50f * Time.deltaTime);
        }
    }
}
