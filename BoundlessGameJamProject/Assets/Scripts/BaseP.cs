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
        hbar = GameObject.Find("LevelManager").GetComponent<Hbar>();
        if(PlayerPrefs.GetInt("MaxHealth") < 100)
        {
            PlayerPrefs.SetInt("MaxHealth", 100);
            maxHealth = PlayerPrefs.GetInt("MaxHealth");
        }
        else
        {
            maxHealth = PlayerPrefs.GetInt("MaxHealth");
        }

        health = maxHealth;
        currHealth = health;

        hbar.SetMaxHealth(maxHealth);

        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(currHealth != health)
        {
            hbar.SetHealth(health);
            currHealth = health;
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
