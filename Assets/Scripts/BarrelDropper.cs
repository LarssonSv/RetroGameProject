using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelDropper : MonoBehaviour
{

    public GameObject bomb;
    public Vector3 spawner;
    public Quaternion bombPosition;
    public float bombRate;
    private float nextBomb;

    ObjectPooler objectPooler;


    void Start()
    {
        objectPooler = ObjectPooler.Instance;
    }


    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextBomb)
        {
            nextBomb = Time.time + bombRate;
            objectPooler.SpawnFromPool("Bomb", spawner, bombPosition);
        }
    }

}
