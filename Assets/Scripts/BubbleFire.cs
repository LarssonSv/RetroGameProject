using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleFire : MonoBehaviour
{

    public float bubbleForce = 750.0f;

    void onTriggerEnter2D (Collider2D target)
    {
        if (target.gameObject.tag == "FirePoint") GetComponent<Rigidbody>().AddForce(transform.right * bubbleForce);
    }
}
