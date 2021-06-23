using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseP : MonoBehaviour
{
    public int health;
    private int maxHealth;
    private int currHealth;
    bool isDead = false;

    Hbar hbar;
    Animator playerAnim;
    public GameObject pauseMenu;
    
    // Start is called before the first frame update
    void Start()
    {
        hbar = GameObject.Find("LevelManager").GetComponent<Hbar>(); //Finds the HealthBar Script

        if(PlayerPrefs.GetInt("MaxHealth") < 100) //This is checking to see what the player health is set to (You can increase it with upgrades)
        {
            PlayerPrefs.SetInt("MaxHealth", 100); //if the health is not default or higher than default it is set back to default
            maxHealth = PlayerPrefs.GetInt("MaxHealth"); //gets the current maxhealth variable that is stores in a file
        }
        else
        {
            maxHealth = PlayerPrefs.GetInt("MaxHealth"); //if value is greater than 100, then it recieves said value from file.
        }

        health = maxHealth; //sets game health to max health
        currHealth = health; //sets the health checker to health

<<<<<<< Updated upstream
        hbar.SetMaxHealth(maxHealth);

        playerAnim = GetComponent<Animator>();
=======
        hbar.SetMaxHealth(maxHealth); //sets the min, max, and current health values for the healthbar
>>>>>>> Stashed changes
    }

    // Update is called once per frame
    void Update()
    {
        if(currHealth != health) //checks to see if the players health has changed
        {
            hbar.SetHealth(health); //resets the health variable for the health bar
            currHealth = health; //resets the health so that it can be rechecked once damaged again
        }

        if (health <= 0 && isDead == false)
        {
            StartCoroutine(PlayerDeath());
        }

    }

    IEnumerator PlayerDeath()
    {
        gameObject.GetComponent<PlayerMovement>().StopAllCoroutines();
        gameObject.GetComponent<PlayerMovement>().enabled = false;
        gameObject.GetComponent<PlayerShooting>().StopAllCoroutines();
        gameObject.GetComponent<PlayerShooting>().enabled = false;
        isDead = true;
        playerAnim.SetTrigger("Dead");
        yield return new WaitForSeconds(3f);
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }
}
