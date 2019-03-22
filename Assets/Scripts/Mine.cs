using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Author: Simon


public class Mine : MonoBehaviour
{
    [SerializeField] int damage = 1;

    List<GameObject> toCheckFor = new List<GameObject>();
    Animator anime;

    private void Start()
    {
        anime = GetComponent<Animator>();
        //THIS IS BAD, I just want to get everthing to a playable state atm, crunch
        toCheckFor.Add(GameManager.GM.CurrentGameMode.currentFishPlayer);
        toCheckFor.Add(GameManager.GM.CurrentGameMode.currentBoatPlayer);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(toCheckFor.Contains(collision.transform.gameObject))
        {
            anime.SetBool("explode", true);
            collision.transform.gameObject.GetComponent<HealthScript>().TakeDamage(damage);
            Invoke("DestroyObject", 1f);
        }
    }

    void DestroyObject()
    {
        this.gameObject.SetActive(false);
    }



}
