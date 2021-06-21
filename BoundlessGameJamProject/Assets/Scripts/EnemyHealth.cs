using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update

    private int TYPE;

    public int health;
    private int maxHealth, currHealth;

    public bool isDeath;

    Color32 hitColor;
    Color32 baseColor;

    SpriteRenderer sprRen;
    void Start()
    {
        if(TYPE == 0)
        {
            maxHealth = 25;
            health = maxHealth;
            currHealth = health;
        }

        sprRen = gameObject.GetComponent<SpriteRenderer>();

        gameObject.transform.GetChild(0).GetComponent<EnemyHbar>().SetHealth(health, maxHealth);

        baseColor = sprRen.color;
        hitColor = new Color32(135, 66, 66, 255);
    }

    // Update is called once per frame
    void Update()
    {
        if(currHealth != health)
        {
            gameObject.transform.GetChild(0).GetComponent<EnemyHbar>().SetHealth(health, maxHealth);
            currHealth = health;
            StartCoroutine(hit());
        }

        if(health <= 0)
        {
            StartCoroutine(death());
        }
    }

    private IEnumerator hit()
    {
        sprRen.color = hitColor;
        yield return new WaitForSeconds(.1f);
        sprRen.color = baseColor;
    }

    private IEnumerator death()
    {
        isDeath = true;
        sprRen.color = hitColor;
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
