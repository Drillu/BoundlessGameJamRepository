using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseP : MonoBehaviour
{
    public int health;
    private int maxHealth;
    private int currHealth;

    Hbar hbar;
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
    }

    // Update is called once per frame
    void Update()
    {
        if(currHealth != health)
        {
            hbar.SetHealth(health);
            currHealth = health;
        }
    }
}
