using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{

    //Publics
    public int startingHealth = 3;
    public int currentHealth;
    public SpriteRenderer damageImage;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);

    //Privats
    private bool isDead;
    private bool damaged;

    void Start()
    {
        currentHealth = startingHealth;
        damageImage = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        if (damaged)
        {
            damageImage.color = flashColour;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;
    }

    public void TakeDamage (int amount)
    {
        damaged = true;
        currentHealth -= amount;
        if(currentHealth <= 0 && !isDead)
        {
            Debug.Log("Took dmg!" + currentHealth);
            Death();
        }
    }

    void Death()
    {
        isDead = true;
        Destroy(gameObject);
    }



}
