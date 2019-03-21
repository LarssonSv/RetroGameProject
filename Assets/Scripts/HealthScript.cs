using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class HealthScript : MonoBehaviour
{

    //Publics
    public int startingHealth = 3;
    public int currentHealth;
    public float flashSpeed = 5f;
    public SpriteRenderer setSpriteColor;

    //Privates
    private bool isDead;
    private bool damaged;

    void Start()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage (int amount)
    {
        damaged = true;
        currentHealth -= amount;
        GetComponent<SpriteRenderer>().color = Color.red;
        StartCoroutine(whitecolor());
        if (currentHealth <= 0 && !isDead)
        {
            Debug.Log("Took dmg!" + currentHealth);
            Death();
        }
    }

    IEnumerator whitecolor()
    {
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }


    void Death()
    {
        if (gameObject.tag == "FishPlayer" && currentHealth <= 0)
        {
            isDead = true;
            Destroy(gameObject);

            Debug.Log("FISH WON");
            Time.timeScale = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        }

        if (gameObject.tag == "BoatPlayer" && currentHealth <= 0)
        {
            isDead = true;
            Destroy(gameObject);

            Debug.Log("BOAT WON");
            Time.timeScale = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }
        if (gameObject.tag == "Enemy" && currentHealth <= 0)
        {
            Debug.Log("ENEMY HIT");

            isDead = true;
            Destroy(gameObject);
        }      
        
            
     }



}
