using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update

    private int TYPE;

    public int health;
    private int maxHealth, currHealth;
    void Start()
    {
        if(TYPE == 0)
        {
            maxHealth = 25;
            health = maxHealth;
            currHealth = health;
        }

        gameObject.transform.GetChild(0).GetComponent<EnemyHbar>().SetHealth(health, maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if(currHealth != health)
        {
            gameObject.transform.GetChild(0).GetComponent<EnemyHbar>().SetHealth(health, maxHealth);
            currHealth = health;
        }
    }
}
