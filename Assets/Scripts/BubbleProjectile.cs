using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleProjectile : MonoBehaviour
{

    [SerializeField] float speed = 200f;

    //temp
    void FixedUpdate()
    {

        transform.Translate(Vector3.forward * speed * Time.fixedDeltaTime);
    }

}
