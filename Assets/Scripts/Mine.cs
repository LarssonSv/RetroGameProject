using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField] int damage = 1;

    GameObject fish;


    private void Start()
    {
        fish = GameManager.GM.CurrentGameMode.currentFishPlayer;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.gameObject == fish )
        {
            fish.GetComponent<HealthScript>().TakeDamage(damage);
            this.gameObject.SetActive(false);
        }
    }



}
